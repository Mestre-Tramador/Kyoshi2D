using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;

/// <summary>
/// Represents the Avatar Kyoshi. <br/>
///
/// It is a <see langword="sealed"/>‏‏‎ ‎<see cref="Character"/>,
/// also a <see cref="Bender"/>.
/// </summary>
public sealed class Kyoshi : Bender
{
    #pragma warning disable CS0108
    /// <summary>
    /// The Disc Index of the Avatar Kyoshi.
    /// </summary>
    private readonly struct DiscIndex
    {
        // TODO: Place some discs.
    }
    #pragma warning restore CS0108

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
            Vector2 direction = (Helper.IsTurnedToRight(transform.localScale) ? Vector2.right : Vector2.left);

            GetComponent<Rigidbody2D>()
            .AddForce(direction * Impulse);

            DisableDashing();

            Helper.GetJukebox().PlayDisc(Character.DiscIndex.Dash);

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
                Helper.GetJukebox().PlayDisc(Character.DiscIndex.Jump);
            }
            
            GetComponent<Rigidbody2D>()
            .AddForce(Vector2.up * Force);

            Jumps++;

            if(Jumps > 1)
            {
                Helper.GetJukebox().PlayDisc(Character.DiscIndex.DoubleJump);

                DisableJumping();
            }
        }
    }

    /// <summary>
    /// Avatar Kyoshi <see langword="override"/> the
    /// Movement event to move to the current faced direction,
    /// wich is switched according to the given Axis.
    /// </summary>
    protected override void OnMovement()
    {        
        float axis = Input.GetAxis("Horizontal");

        float x = Helper.CalculateXPosition(axis, Speed);

        if((x > 0.0f && Helper.IsTurnedToLeft(transform.localScale)) || (x < 0.0f && Helper.IsTurnedToRight(transform.localScale)))
        {
            Helper.Turn(gameObject);
        }

        transform.Translate(new Vector3(x, 0.0f, 0.0f));

        if(axis != 0 && Helper.IsPlayerTouchingFloor())
        {
            Helper.GetJukebox().PlayDiscIfNotPlaying(Character.DiscIndex.Move);            
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
        .ReplaceDisc(
            Character.DiscIndex.Move,
            Helper.LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.KyoshiMove}")
        )
        .ReplaceDisc(
            Character.DiscIndex.Jump,
            Helper.LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.KyoshiJump}")
        )
        .ReplaceDisc(
            Character.DiscIndex.DoubleJump,
            Helper.LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.KyoshiDoubleJump}")
        )
        .ReplaceDisc(
            Character.DiscIndex.Dash,
            Helper.LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.KyoshiDash}")
        );
    }

    /// <summary>
    /// Avatar Kyoshi <see langword="override"/> the
    /// Start to enable the Jump and Dash events,
    /// also the Bend events. <br/>
    ///
    /// The values for the properties are setted.
    /// </summary>
    protected override void Start()
    {
        base.Start();

        EnableJumping();
        EnableDashing();

        Speed   = Player.Speed;
        Force   = Player.Force;
        Impulse = Player.Impulse;

        RefreshJump();

        BecomeAvatar();

        SetDiscs();

        BendCursor.SetDefault();
        BendCursor.Unhide();
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
    /// The TriggerEnter checks for refresh
    /// the Jumps.
    /// </summary>
    /// <param name="other">The other GameObject that was collided.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(Tags.Floor))
        {
            RefreshJump();
        }
    }
}