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
    /// An offset when pulling by the X axis.
    /// </summary>
    /// <value>Generally a hard coded number.</value>
    private float OffsetX { get; set; }

    /// <summary>
    /// An offset when pulling by the Y axis.
    /// </summary>
    /// <value>Generally a hard coded number.</value>
    private float OffsetY { get; set; }

    /// <summary>
    /// The minimum X axis value the Bend can be pulled.
    /// </summary>
    /// <value>Generally a hard coded number.</value>
    private float MinX { get; set; }

    /// <summary>
    /// The maximum X axis value the Bend can be pulled.
    /// </summary>
    /// <value>Generally a hard coded number.</value>
    private float MaxX { get; set; }

    /// <summary>
    /// The minimum Y axis value the Bend can be pulled.
    /// </summary>
    /// <value>Generally a hard coded number.</value>
    private float MinY { get; set; }

    /// <summary>
    /// The maximum Y axis value the Bend can be pulled.
    /// </summary>
    /// <value>Generally a hard coded number.</value>
    private float MaxY { get; set; }

    /// <summary>
    /// Completely make the source unbendable.
    /// </summary>
    public override void MakeUnbendable()
    {
        GetJukebox().PlayDisc(DiscIndex.Impact);

        base.MakeUnbendable();
    }

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
    /// From the current position, follow the cursor
    /// on a single axis based on the given parameter.
    /// </summary>
    /// <param name="endPosition">The ending position to pull.</param>
    private void Follow(Vector2 endPosition)
    {
        transform.position = Vector2.Lerp(transform.position, endPosition, 1.0f);

        GetJukebox().PlayDiscIfNotPlaying(DiscIndex.Pull);
    }

    /// <summary>
    /// <see cref="Follow(Vector2)"/> the Cursor only on X axis.
    /// </summary>
    /// <param name="offsetX">An offset, if needed.</param>
    private void FollowByX(float offsetX = 0.0f) => Follow(new Vector2((CurrentMouseWorldPoint().x) + offsetX, transform.position.y));

    /// <summary>
    /// <see cref="Follow(Vector2)"/> the Cursor only on Y axis.
    /// </summary>
    /// <param name="offsetX">An offset, if needed.</param>
    private void FollowByY(float offsetY = 0.0f) => Follow(new Vector2(transform.position.x, (CurrentMouseWorldPoint().y + offsetY)));

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

                        FollowByX(OffsetX);
                    break;

                    case Tags.Fire:
                        GetKyoshi().BendFire();

                        if(!IsBetween(transform.position.y, MinY, MaxY))
                        {
                            Vector2 fixedPosition = new Vector2(
                                transform.position.x,
                                (transform.position.y >= MaxY ? (MaxY - 0.25f) : (MinY + 0.25f))
                            );

                            Follow(fixedPosition);

                            break;
                        }

                        FollowByY(OffsetY);
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


                        MakeUnbendable();
                    }
                }
            break;
            case Tags.Fire:
                if(SceneLoader.Get("Book") == SceneData.BookFire.Value)
                {
                    if(other.CompareTag(tag))
                    {
                        base.BlockBending();

                        transform.position = new Vector2(transform.position.x, MaxY);

                        GameObject.Find(GameObjectNames.Altar)
                        .GetComponent<BookEnd>()
                        .EndFireBook();

                        MakeUnbendable();
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

        switch(tag)
        {
            case Tags.Earth:
                OffsetX = 26.0f;
            break;
            case Tags.Fire:
                OffsetY = -0.5f;
                MinY = 0.0f;
                MaxY = 2.25f;
            break;
        }

        AudioClip GetPullDisc()
        {
            switch(tag)
            {
                case Tags.Earth: return LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.EarthPull}");

                case Tags.Fire: return LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.FirePull}");

                default: return null;
            }
        }

        AudioClip GetImpactDisc()
        {
            switch(tag)
            {
                case Tags.Earth: return LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.EarthImpact}");

                case Tags.Fire: return LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.FireImpact}");

                default: return null;
            }
        }
    }
}
