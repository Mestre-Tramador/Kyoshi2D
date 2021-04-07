using System.Collections;
using UnityEngine;

/// <summary>
/// Represents a base Character.
/// </summary>
public abstract class Character : MonoBehaviour
{
    /// <summary>
    /// The index of all the possible Character Discs.
    /// </summary>
    protected readonly struct DiscIndex
    {
        /// <summary>
        /// The disc for the Movement event.
        /// </summary>
        public const int Move = 1;

        /// <summary>
        /// The disc for the Jump event.
        /// </summary>
        public const int Jump = 2;

        /// <summary>
        /// The disc for the Double Jump event.
        /// </summary>
        public const int DoubleJump = 3;
        
        /// <summary>
        /// The disc for the Dash event.
        /// </summary>
        public const int Dash = 4;
    }

    /// <summary>
    /// Controls if the <see cref="Character"/> can dash.
    /// </summary>
    /// <value><see langword="true"/> if it can.</value>
    public bool CanDash { get; private set; }

    /// <summary>
    /// Controls if the <see cref="Character"/> can jump.
    /// </summary>
    /// <value><see langword="true"/> if it can.</value>
    public bool CanJump { get; private set; }

    /// <summary>
    /// Controls if the <see cref="Character"/> can move.
    /// </summary>
    /// <value><see langword="true"/> if it can.</value>
    public bool CanMove { get; private set; }

    /// <summary>
    /// Represents the Force used to impulsionate the jumping.
    /// </summary>
    /// <value>Any numeric value above zero.</value>
    public float Force { get; protected set; }

    /// <summary>
    /// Represents the Impulse used to dash.
    /// </summary>
    /// <value>Any numeric value above zero.</value>
    public float Impulse { get; protected set; }

    /// <summary>
    /// Represents the amount of Speed used to calculate the movement.
    /// </summary>
    /// <value>Any numeric value above zero.</value>
    public float Speed { get; protected set; }

    /// <summary>
    /// The amount of Jumps that a character did.
    /// </summary>
    /// <value></value>
    public int Jumps { get; protected set; }

    /// <summary>
    /// Disable the Dash control.
    /// </summary>
    public void DisableDashing() => CanDash = false;

    /// <summary>
    /// Enable the Dash control.
    /// </summary>
    public void EnableDashing() => CanDash = true;

    /// <summary>
    /// Disable the Jump control.
    /// </summary>
    public void DisableJumping() => CanJump = false;

    /// <summary>
    /// Enable the Jump control.
    /// </summary>
    public void EnableJumping() => CanJump = true;

    /// <summary>
    /// All in one, disable respectively:
    /// <list type="bullet">
    /// <item>Movement;</item>
    /// <item>Jump;</item>
    /// <item>Dash.</item>
    /// </list>
    /// </summary>
    public void DisableMovement()
    {
        DisableMoving();
        DisableJumping();
        DisableDashing();
    }

    /// <summary>
    /// All in one, enable respectively:
    /// <list type="bullet">
    /// <item>Movement;</item>
    /// <item>Jump;</item>
    /// <item>Dash.</item>
    /// </list>
    /// </summary>
    public void EnableMovement()
    {
        EnableMoving();
        EnableJumping();
        EnableDashing();
    }

    /// <summary>
    /// Disable the Movement control.
    /// </summary>
    public void DisableMoving() => CanMove = false;

    /// <summary>
    /// Enable the Movement control.
    /// </summary>
    public void EnableMoving() => CanMove = true;

    /// <summary>
    /// The Dash event. <br/>
    ///
    /// As <see langword="abstract"/>,
    /// it depends on each <see cref="Character"/>.
    /// </summary>
    protected abstract void OnDash();

    /// <summary>
    /// The Jump event. <br/>
    ///
    /// As <see langword="abstract"/>,
    /// it depends on each <see cref="Character"/>.
    /// </summary>
    protected abstract void OnJump();

    /// <summary>
    /// The Movement event. <br/>
    ///
    /// As <see langword="abstract"/>,
    /// it depends on each <see cref="Character"/>.
    /// </summary>
    protected abstract void OnMovement();

    /// <summary>
    /// The <see langword="virtual"/> Refresher
    /// for the Dash event. <br/>
    ///
    /// Consequently, it can be overwritten
    /// to each <see cref="Character"/> specification.
    /// </summary>
    /// <returns>The <see cref="IEnumerator"/> of the Coroutine.</returns>
    protected virtual IEnumerator RefreshDash()
    {
        yield return new WaitForSeconds(2.0f);

        EnableDashing();
    }

    /// <summary>
    /// The <see langword="virtual"/> Refresher
    /// for the Jump event. <br/>
    ///
    /// Consequently, it can be overwritten
    /// to each <see cref="Character"/> specification.
    /// </summary>
    protected virtual void RefreshJump()
    {
        Jumps = 0;

        EnableJumping();
    }

    /// <summary>
    /// Set the current indexed discs to the Character. <br/>
    /// 
    /// Beeing a <see langword="virtual"/> method, it can be overwritten
    /// to fit any Character.
    /// </summary>
    protected virtual void SetDiscs()
    {
        // ? Base characters does not set any Jukebox discs.
    }

    /// <summary>
    /// The <see langword="virtual"/> Starter
    /// already enables the Movement. <br/>
    ///
    /// Consequently, it can be overwritten
    /// to each <see cref="Character"/> specification.
    /// </summary>
    protected virtual void Start()
    {
        EnableMoving();
    }

    /// <summary>
    /// Dash event listener.
    /// </summary>
    protected void ListenToDash()
    {
        if(!CanDash)
        {
            return;
        }

        OnDash();
    }

    /// <summary>
    /// Jump event listener.
    /// </summary>
    protected void ListenToJump()
    {
        if(!CanJump)
        {
            return;
        }

        OnJump();
    }

    /// <summary>
    /// Movement event listener.
    /// </summary>
    protected void ListenToMovement()
    {
        if(!CanMove)
        {
            return;
        }

        OnMovement();
    }
}