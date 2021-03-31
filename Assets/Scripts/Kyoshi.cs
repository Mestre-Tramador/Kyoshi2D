using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;

public sealed class Kyoshi : Bender
{
    protected override void OnAirBending()
    {
        Debug.Log($"{name} is bending Air!");
    }

    protected override void OnDash()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            float x = (Helper.IsTurnedToRight(transform.localScale) ? 1.0f : -1.0f);

            GetComponent<Rigidbody2D>()
            .AddForce(new Vector2(x, 0.0f) * Player.DashForce);

            disableDashing();

            StartCoroutine(RefreshDash());
        }
    }

    protected override void OnEarthBending()
    {
        Debug.Log($"{name} is bending Earth!");
    }

    protected override void OnFireBending()
    {
        Debug.Log($"{name} is bending Fire!");
    }

    protected override void OnJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Jumps <= 1)
        {
            GetComponent<Rigidbody2D>()
            .AddForce(new Vector2(0.0f, 1.0f) * Force);

            Jumps++;

            if(Jumps > 1)
            {
                disableJumping();
            }
        }
    }

    protected override void OnMovement()
    {
        float x = Helper.CalculateXPosition(Input.GetAxis("Horizontal"), Speed);

        if((x > 0.0f && Helper.IsTurnedToLeft(transform.localScale)) || (x < 0.0f && Helper.IsTurnedToRight(transform.localScale)))
        {
            Helper.Turn(gameObject);
        }

        transform.Translate(new Vector3(x, 0.0f, 0.0f));
    }        

    protected override void OnWaterBending()
    {
        Debug.Log($"{name} is bending Water!");
    }

    protected override void Start()
    {
        base.Start();

        enableJumping();
        enableDashing();

        Speed = Player.Speed;
        Force = Player.JumpForce;

        RefreshJump();

        BecomeAvatar();

        BendCursor.SetDefault();
    }

    private void Update()
    {
        ListenToMovement();
        ListenToJump();
        ListenToDash();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RefreshJump();
    }   
}
