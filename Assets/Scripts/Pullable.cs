using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;
using static MestreTramadorEMulherMotoca.Util.Helper;

/// <summary>
/// A kind of Bendable source which can be pulled.
/// </summary>
public sealed class Pullable : Bendable
{

    /// <summary>
    /// This <see langword="override"/> of the Bending
    /// use blocker additionally stop the Pull Jukebox disc.
    /// </summary>
    protected override void BlockBending()
    {
        GetJukebox().StopDisc(DiscIndex.Pull);

        base.BlockBending();
    }

    /// <summary>
    /// Follow the Cursor only on X axis.
    /// </summary>
    /// <param name="offsetX">An offset, if needed.</param>
    private void Follow(float offsetX = 0.0f)
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(CurrentMouseWorldPoint().x + offsetX, transform.position.y), 1.0f);

        GetJukebox().PlayDiscIfNotPlaying(DiscIndex.Pull);
    }

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
                        GetKyoshi().BendAir();
                    break;

                    case Tags.Earth:
                        GetKyoshi().BendEarth();

                        const float offsetX = 26.0f;

                        Follow(offsetX);
                    break;

                    case Tags.Fire:
                        GetKyoshi().BendFire();
                    break;

                    case Tags.Water:
                        GetKyoshi().BendWater();
                    break;
                }

                IsBending = true;

                GetKyoshi().DisableMovement();

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
    /// <param name="other">The collider which had triggered.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch(tag)
        {
            case Tags.Earth:
                if(SceneLoader.Get("Book") == SceneData.BookEarth.Value)
                {
                    if(other.CompareTag(GetPlayerTag()))
                    {
                        base.BlockBending();

                        transform.position = new Vector2(GetPlayerPosition().x, transform.position.y);

                        GameObject.Find(GameObjectNames.Cliff)
                        .GetComponent<BookEnd>()
                        .EndEarthBook();

                        GetJukebox().PlayDisc(DiscIndex.Impact);

                        Destroy(this);
                    }
                }
            break;
        }
    }

    /// <summary>
    /// The Starter loads and sets the Pull and Impact Jukebox discs.
    /// </summary>
    private void Start()
    {
        Helper
        .GetJukebox()
        .AddDisc(DiscIndex.Pull, GetPullDisc())
        .AddDisc(DiscIndex.Impact, GetImpactDisc());

        AudioClip GetPullDisc()
        {
            switch(tag)
            {
                case Tags.Earth: return LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.EarthPull}");

                default: return null;
            }
        }

        AudioClip GetImpactDisc()
        {
            switch(tag)
            {
                case Tags.Earth: return LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.EarthImpact}");

                default: return null;
            }
        }
    }
}
