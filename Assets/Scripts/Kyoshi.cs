using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;
using static MestreTramadorEMulherMotoca.Util.Helper;

/// <summary>
/// Represents the Avatar Kyoshi. <br/>
///
/// It is a <see langword="sealed"/>‏‏‎ ‎<see cref="Character"/>,
/// also a <see cref="Bender"/>.
/// </summary>
public sealed class Kyoshi : Bender
{
    /// <summary>
    /// Avatar Kyoshi <see langword="override"/> the <see cref="Character.EnableMovement"/>
    /// method to only enable according to the Book.
    /// </summary>
    #pragma warning disable CS0108
    public void EnableMovement()
    {
        if(int.TryParse(SceneLoader.Get("Book"), out int index))
        {
            switch(index)
            {
                case 1:
                    EnableMoving();
                break;

                case 2:
                    EnableJumping();
                goto case 1;

                case 3:
                case 4:
                    base.EnableMovement();
                break;
            }
        }
        else
        {
            base.EnableMovement();
        }
    }
    #pragma warning restore CS0108

    /// <summary>
    /// Place Avatar Kyoshi above layers.
    /// </summary>
    public void PlaceAbove() => GetComponent<SpriteRenderer>().sortingOrder = 10;

    /// <summary>
    /// Place Avatar Kyoshi below layers.
    /// </summary>
    public void PlaceBelow() => GetComponent<SpriteRenderer>().sortingOrder = 0;

    /// <summary>
    /// Avatar Kyoshi <see langword="override"/> the
    /// Air Bend event.
    /// </summary>
    protected override void OnAirBending()
    {
        Debug.Log($"{name} is bending Air!");
    }

    /// <summary>
    /// Avatar Kyoshi <see langword="override"/> the
    /// Dash event to impulsionate on the current direction,
    /// then disable it and start the refreshing.
    /// </summary>
    protected override void OnDash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            Vector2 direction = (IsTurnedToRight(transform.localScale) ? Vector2.right : Vector2.left);

            GetComponent<Rigidbody2D>()
            .AddForce(direction * Impulse);

            DisableDashing();

            GetJukebox().PlayDisc(DiscIndex.Dash);

            StartCoroutine(RefreshDash());
        }
    }

    /// <summary>
    /// Avatar Kyoshi <see langword="override"/> the
    /// Earth Bend event.
    /// </summary>
    protected override void OnEarthBending()
    {
        Debug.Log($"{name} is bending Earth!");
    }

    /// <summary>
    /// Avatar Kyoshi <see langword="override"/> the
    /// Fire Bend event.
    /// </summary>
    protected override void OnFireBending()
    {
        Debug.Log($"{name} is bending Fire!");
    }

    /// <summary>
    /// Avatar Kyoshi <see langword="override"/> the
    /// Jump event to impulsionate to upwards in maximum
    /// two times, then it is disabled.
    /// </summary>
    protected override void OnJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Jumps <= 1)
        {
            if(Jumps == 0)
            {
                GetJukebox().PlayDisc(DiscIndex.Jump);
            }

            GetComponent<Rigidbody2D>()
            .AddForce(Vector2.up * Force);

            Jumps++;

            if(Jumps > 1)
            {
                GetJukebox().PlayDisc(DiscIndex.DoubleJump);

                DisableJumping();
            }
        }
    }

    /// <summary>
    /// Avatar Kyoshi <see langword="override"/> the
    /// Movement event to move to the current faced direction,
    /// which is switched according to the given Axis.
    /// </summary>
    protected override void OnMovement()
    {
        float axis = Input.GetAxis("Horizontal");

        float x = CalculateXPosition(axis, Speed);

        if((x > 0.0f && IsTurnedToLeft(transform.localScale)) || (x < 0.0f && IsTurnedToRight(transform.localScale)))
        {
            Turn(gameObject);
        }

        transform.Translate(new Vector3(x, 0.0f, 0.0f));

        bool isWalking = (axis != 0);

        SetWalkingAnimation(isWalking);

        if(isWalking && IsPlayerTouchingFloor())
        {
            GetJukebox().PlayDiscIfNotPlaying(DiscIndex.Move);
        }
    }

    /// <summary>
    /// Avatar Kyoshi <see langword="override"/> the
    /// Water Bend event.
    /// </summary>
    protected override void OnWaterBending()
    {
        Debug.Log($"{name} is bending Water!");
    }

    /// <summary>
    /// Place on the <see cref="Jukebox"/> the discs for Avatar Kyoshi.
    /// </summary>
    protected override void SetDiscs()
    {
        Helper
        .GetJukebox()
        // .ReplaceDiscOne()
        .ReplaceDisc(DiscIndex.Move, LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.KyoshiMove}"))
        .ReplaceDisc(DiscIndex.Jump, LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.KyoshiJump}"))
        .ReplaceDisc(DiscIndex.DoubleJump, LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.KyoshiDoubleJump}"))
        .ReplaceDisc(DiscIndex.Dash, LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.KyoshiDash}"));
    }

    /// <summary>
    /// By the current Book, set the controls for the Avatar Kyoshi.
    /// </summary>
    private void SetControls()
    {
        if(int.TryParse(SceneLoader.Get("Book"), out int index))
        {
            switch(index)
            {
                case 1:
                    EnableEarthBending();
                break;

                case 2:
                    EnableJumping();
                    RefreshJump();
                    EnableFireBending();
                goto case 1;

                case 3:
                    EnableDashing();
                    EnableDoubleJumping();
                    EnableAirBending();
                goto case 2;

                case 4:
                    EnableWaterBending();
                goto case 3;

                default:
                    base.EnableMovement();
                    BecomeAvatar();
                break;
            }
        }
        else
        {
            base.EnableMovement();
            BecomeAvatar();
        }
    }

    /// <summary>
    /// Avatar Kyoshi <see langword="override"/> the
    /// Starter to, according to the book,
    /// enable Jump, Double Jump, Dash and also the Bend events. <br/>
    ///
    /// The values for the properties are setted. <br/>
    /// The Cursor is also set to the Default theme.
    /// </summary>
    protected override void Start()
    {
        base.Start();

        SetDiscs();

        BendCursor.SetDefault();

        Speed   = Player.Speed;
        Force   = Player.Force;
        Impulse = Player.Impulse;

        SetControls();
    }

    /// <summary>
    /// The Updater keeps checking for the
    /// Movement, Jump and Dash events.
    /// </summary>
    private void Update()
    {
        ListenToMovement();
        ListenToJump();
        ListenToDash();
    }

    /// <summary>
    /// The TriggerEnter checks for refresh the Jumps if possible.
    /// </summary>
    /// <param name="other">The other GameObject that was collided.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(Tags.Floor) && SceneLoader.Get("Book") != SceneData.BookEarth.Value)
        {
            RefreshJump();
            EnableJumping();
        }
    }
}