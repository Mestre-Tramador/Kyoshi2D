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
            GetComponent<Rigidbody2D>()
            .AddForce(Vector2.up * Force);

            Jumps++;

            if(Jumps > 1)
            {
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
        float x = Helper.CalculateXPosition(Input.GetAxis("Horizontal"), Speed);

        if((x > 0.0f && Helper.IsTurnedToLeft(transform.localScale)) || (x < 0.0f && Helper.IsTurnedToRight(transform.localScale)))
        {
            Helper.Turn(gameObject);
        }

        transform.Translate(new Vector3(x, 0.0f, 0.0f));
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

        BendCursor.SetDefault();
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
        RefreshJump();
    }
}