using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;

/// <summary>
/// A kind of Bendable source wich can be pulled.
/// </summary>
public sealed class Pullable : Bendable
{
    /// <summary>
    /// Follow the Cursor only on X axis.
    /// </summary>
    /// <param name="offsetX">An offset, if needed.</param>
    private void Follow(float offsetX = 0.0f) => transform.position = Vector2.Lerp(transform.position, new Vector2(Helper.CurrentMouseWorldPoint().x + offsetX, transform.position.y), 1.0f);
    
    /// <summary>
    /// The Updater keeps the verification
    /// if the source is ready and if the Mouse LButton
    /// was kept pressed, to then pull the source. <br/>
    ///
    /// Else, the Bending is blocked until the Mouse LButton is pressed again.
    /// </summary>
    private void FixedUpdate()
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

                        const float offsetX = 26.0f;

                        Follow(offsetX);
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
        }
    }

    /// <summary>
    /// The Mouse Exitter do nothing.
    /// </summary>
    private void OnMouseExit()
    {
        // ? Nothing must occur on the MouseExit...
    }

    /// <summary>
    /// The Trigger Enter do an extensive verification to execute an action. <br/>
    /// 
    /// <list type="bullet">
    /// <item>If its an Earth Pullable on the first level and it reaches the player,
    /// then the book is ended.</item>
    /// </list>
    /// </summary>
    /// <param name="other">The collider wich had triggered.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch(tag)
        {
            case Tags.Earth:
                if(SceneLoader.Get("Book") == SceneData.BookEarth.Value)
                {
                    if(other.CompareTag(Helper.GetPlayerTag()))
                    {
                        base.BlockBending();

                        transform.position = new Vector2(Helper.GetPlayerPosition().x, transform.position.y);
                        
                        GameObject.Find(GameObjectNames.Cliff)
                        .GetComponent<BookEnd>()
                        .EndEarthBook();
                        
                        Destroy(this);
                    }
                }
            break;
        }
    }
}
