using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;

/// <summary>
/// Represents a Bendable source.
/// </summary>
public class Bendable : MonoBehaviour
{
    /// <summary>
    /// Determine if the source is ready to be bended.
    /// </summary>
    /// <value><see langword="true"/> to become ready.</value>
    public bool ReadyToBend { get; private set; }

    /// <summary>
    /// Determine if the source is been used to be bended.
    /// </summary>
    /// <value><see langword="true"/> if is been used.</value>
    private bool IsBending { get; set; }

    /// <summary>
    /// Allow the use of Bending on the source.
    /// </summary>
    private void AllowBending()
    {
        BendCursor.Set(tag);

        ReadyToBend = true;
    }

    /// <summary>
    /// Block the use of Bending on the source.
    /// </summary>
    private void BlockBending()
    {
        ReadyToBend = false;

        BendCursor.SetDefault();

        Cursor.visible = true;
    }

    /// <summary>
    /// The Fixed Updater keeps the verification
    /// if the source is ready and if the Mouse LButton
    /// was kept pressed, to then use the current Bending. <br/>
    ///
    /// Else, the Bending is blocked until the Mouse LButton is pressed again.
    /// </summary>
    private void FixedUpdate()
    {
        if(ReadyToBend)
        {
            if(Input.GetMouseButton(0))
            {
                Cursor.visible = false;

                switch(tag)
                {
                    case Tags.Air:
                        Helper.GetKyoshi().BendAir();
                    break;

                    case Tags.Earth:
                        Helper.GetKyoshi().BendEarth();
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

    /// <summary>
    /// If the source is bended,
    /// when the Mouse is exited,
    /// then a bend is used.
    /// </summary>
    private void OnMouseExit()
    {
        if(IsBending)
        {
            switch(tag)
            {
                case Tags.Air:
                    UseAirBall();
                break;

                case Tags.Earth:
                    UseEarthBoulder();
                break;

                case Tags.Fire:
                    UseFireStream();
                break;

                case Tags.Water:
                    UseWaterWhip();
                break;
            }

            return;
        }

        BlockBending();
    }

    /// <summary>
    /// When the Mouse is over,
    /// if not Bending,
    /// the bend itself is allowed.
    /// </summary>
    private void OnMouseOver()
    {
        if(!IsBending)
        {
            AllowBending();
        }
    }

    /// <summary>
    /// The Starter just set the initial values to the properties.
    /// </summary>
    private void Start()
    {
        ReadyToBend = false;
        IsBending = false;
    }

    /// <summary>
    /// To use a bend, a new Instance of it is spawned as a GameObject.
    /// </summary>
    /// <param name="path">The path to the GameObject.</param>
    private void UseBend(string path)
    {
        GameObject bend = Instantiate(
            Helper.LoadResource<GameObject>(path),
            Helper.CurrentMouseWorldPoint(),
            Quaternion.identity
        );

        Physics2D.IgnoreCollision(bend.GetComponent<Collider2D>(), Helper.GetPlayer().GetComponent<Collider2D>());
    }

    /// <summary>
    /// Use the Air Ball Bending.
    /// </summary>
    private void UseAirBall() => UseBend($"{Path.Prefab}{GameObjects.AirBall}");

    /// <summary>
    /// Use the Earth Boulder Bending.
    /// </summary>
    private void UseEarthBoulder() => UseBend($"{Path.Prefab}{GameObjects.EarthBoulder}");

    /// <summary>
    /// Use the Fire Stream Bending.
    /// </summary>
    private void UseFireStream() => UseBend($"{Path.Prefab}{GameObjects.FireStream}");

    /// <summary>
    /// Use the Water Whip Bending.
    /// </summary>
    private void UseWaterWhip() => UseBend($"{Path.Prefab}{GameObjects.WhaterWhip}");
}