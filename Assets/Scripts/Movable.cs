using System.Collections;
using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;

/// <summary>
/// A kind of Bendable source wich can be moved.
/// </summary>
public sealed class Movable : Bendable
{
    /// <summary>
    /// Determines if the Movable is not overlapping the floor.
    /// </summary>
    /// <value><see langword="false"/> if the source is not overlapping the floor.</value>
    private bool IsOverlappingFloor { get; set; }

    /// <summary>
    /// Completely make the source unbendable.
    /// </summary>
    public void MakeUnbendable()
    {
        base.BlockBending();

        Helper.GetKyoshi().EnableMovement();        

        if(TryGetComponent<Collider2D>(out Collider2D collider))
        {
            Destroy(collider);
        }

        if(TryGetComponent<Rigidbody2D>(out Rigidbody2D body))
        {
            Destroy(body);
        }

        Destroy(this);
    }

    /// <summary>
    /// This <see langword="override"/> only allows bending if the source
    /// is not overlapping ground.
    /// </summary>
    protected override void AllowBending()
    {
        if(!IsOverlappingFloor)
        {
            base.AllowBending();
        }
        else if(!Helper.GetAnyMouseClick())
        {
            StartCoroutine(RefreshOverlap());
        }

        IEnumerator RefreshOverlap()
        {
            yield return new WaitForSecondsRealtime(1.0f);

            IsOverlappingFloor = false;
        }
    }

    /// <summary>
    /// This <see langword="override"/> of the Bending
    /// use blocker only does not change the Bend Cursor.
    /// </summary>
    protected override void BlockBending()
    {
        if(Helper.GameIsPaused())
        {
            return;
        }

        ReadyToBend = false;

        BendCursor.Unhide();
    }

    /// <summary>
    /// Check if the other is tagged as a Barrier or as the Player.
    /// </summary>
    /// <param name="other">The reference GameObject.</param>
    /// <returns><see langword="true"/> if is at least one of the cases.</returns>
    private bool OtherIsBarrierOrPlayer(GameObject other) => (other.CompareTag(Tags.Barrier) || other.CompareTag(Helper.GetPlayerTag()));

    /// <summary>
    /// Add rigidity to the source.
    /// </summary>
    private void AddRigidity()
    {
        if(!TryGetComponent<Rigidbody2D>(out Rigidbody2D body))
        {
            body = gameObject.AddComponent<Rigidbody2D>();
        }

        body.constraints = RigidbodyConstraints2D.FreezeRotation;

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), Helper.GetPlayerComponent<Collider2D>());

        GetComponent<Collider2D>().isTrigger = false;
    }

    /// <summary>
    /// The Fixed Updater do nothing.
    /// </summary>
    private void FixedUpdate()
    {
        // ? Nothing must occur on the FixedUpdate...
    }

    /// <summary>
    /// If not overlapping, the bend follows the Cursor.
    /// </summary>
    private void Follow()
    {
        if(!IsOverlappingFloor)
        {
            transform.position = Vector2.Lerp(transform.position, Helper.CurrentMouseWorldPoint(), 1.0f);
        }
    }

    /// <summary>
    /// On the Collision Enter, it checks if is not an Obstacle, its Barrier or the Player,
    /// then, if it is overlapping the Floor, disable the Bending, and finally remove the rigidity.
    /// </summary>
    /// <param name="other">The collider wich had collided.</param>
    private void OnCollisionEnter2D(Collision2D other) 
    {
        IsOverlappingFloor = false;

        if(OtherIsBarrierOrPlayer(other.gameObject) || other.gameObject.GetComponent<Obstacle>())    
        {
            return;
        }

        if(other.gameObject.CompareTag(Tags.Floor))
        {
            IsBending = false;

            BlockBending();

            Helper.GetKyoshi().EnableMovement();

            IsOverlappingFloor = true;        
        }

        RemoveRigidity();
    }

    /// <summary>
    /// When the mouse is exit, then the Bend Cursor is changed.
    /// </summary>
    private void OnMouseExit() => BendCursor.SetDefault();

    /// <summary>
    /// On the Trigger Enter, if its not a Barrier or the Player,
    /// then the ridigity is removed.
    /// </summary>
    /// <param name="other">The collider wich had triggered.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(OtherIsBarrierOrPlayer(other.gameObject))    
        {
            return;
        }

        RemoveRigidity();
    }
        
    /// <summary>
    /// Remove the rigidity of the body.
    /// </summary>
    /// <param name="andMakeTrigger">It also naturally make it a trigger.</param>
    private void RemoveRigidity(bool andMakeTrigger = true)
    {
        GetComponent<Collider2D>().isTrigger = andMakeTrigger;

        Destroy(GetComponent<Rigidbody2D>());
    }

    /// <summary>
    /// The Updater keeps the verification
    /// if the source is ready and if the Mouse LButton
    /// was kept pressed, to then move the source. <br/>
    ///
    /// Else, the Bending is blocked until the Mouse LButton is pressed again.
    /// </summary>
    private void Update()
    {
        if(ReadyToBend)
        {
            if(Input.GetMouseButton(0))
            {
                BendCursor.Hide();

                switch(tag)
                {
                    case Tags.Air:
                        Helper.GetKyoshi().BendAir();
                    break;

                    case Tags.Earth:
                        Helper.GetKyoshi().BendEarth();
                        
                        AddRigidity();
                        
                        Follow();
                    break;

                    case Tags.Fire:
                        Helper.GetKyoshi().BendFire();
                    break;

                    case Tags.Water:
                        Helper.GetKyoshi().BendWater();
                    break;
                }

                IsBending = true;

                Helper.GetKyoshi().DisableMovement();

                return;
            }

            IsBending = false;

            BlockBending();

            Helper.GetKyoshi().EnableMovement();
        }
    }        
}
