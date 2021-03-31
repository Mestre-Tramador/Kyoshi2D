using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public bool CanMove { get; private set; }

    public bool CanJump { get; private set; }

    public bool CanDash { get; private set; }

    public float Speed { get; protected set; }

    public float Force { get; protected set; }

    public int Jumps { get; protected set; }

    public void enableMoving() => CanMove = true;

    public void disableMoving() => CanMove = false;

    public void enableJumping() => CanJump = true;

    public void disableJumping() => CanJump = false;

    public void enableDashing() => CanDash = true;

    public void disableDashing() => CanDash = false;

    protected virtual void Start()
    {
        enableMoving();
    }

    protected void ListenToDash()
    {
        if(!CanDash)
        {
            return;
        }

        OnDash();
    }

    protected void ListenToJump()
    {
        if(!CanJump)
        {
            return;
        }

        OnJump();
    }

    protected void ListenToMovement()
    {
        if(!CanMove)
        {
            return;
        }

        OnMovement();
    }

    protected abstract void OnDash();

    protected abstract void OnJump();

    protected abstract void OnMovement();

    protected void RefreshJump()
    {
        Jumps = 0;

        enableJumping();
    }
 
    protected IEnumerator RefreshDash()
    {
        yield return new WaitForSeconds(2.0f);

        enableDashing();
    }
}
