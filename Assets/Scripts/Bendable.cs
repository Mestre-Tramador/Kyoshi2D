using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;
using static MestreTramadorEMulherMotoca.Util.Helper;

/// <summary>
/// Represents a Bendable source.
/// </summary>
public class Bendable : MonoBehaviour
{
    /// <summary>
    /// Determine if the source is ready to be bended.
    /// </summary>
    /// <value><see langword="true"/> to become ready.</value>
    protected bool ReadyToBend { get; set; }

    /// <summary>
    /// Determine if the source is been used to be bended.
    /// </summary>
    /// <value><see langword="true"/> if is been used.</value>
    protected bool IsBending { get; set; }

    /// <summary>
    /// Remove completely the Bendable source, aka the script itself, of the object.
    /// </summary>
    public virtual void MakeUnbendable() => Destroy(this);

    /// <summary>
    /// Allow the use of Bending on the source.
    /// </summary>
    protected virtual void AllowBending()
    {
        if(GameIsPaused())
        {
            return;
        }

        BendCursor.Set(tag);

        ReadyToBend = true;
    }

    /// <summary>
    /// Block the use of Bending on the source.
    /// </summary>
    protected virtual void BlockBending()
    {
        if(GameIsPaused())
        {
            return;
        }

        ReadyToBend = false;

        BendCursor.SetDefault();

        BendCursor.Unhide();
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
                BendCursor.Hide();

                switch(tag)
                {
                    case Tags.Air:
                        GetKyoshi().BendAir();
                    break;

                    case Tags.Earth:
                        GetKyoshi().BendEarth();
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

            GetKyoshi().EnableMovement();
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
        GameObject bend = Instantiate(LoadResource<GameObject>(path), CurrentMouseWorldPoint(), Quaternion.identity);

        Physics2D.IgnoreCollision(bend.GetComponent<Collider2D>(), GetPlayerComponent<Collider2D>());
    }

    /// <summary>
    /// Use the Air Ball Bending.
    /// </summary>
    private void UseAirBall() => UseBend($"{Path.Prefab}{GameObjectNames.AirBall}");

    /// <summary>
    /// Use the Earth Boulder Bending.
    /// </summary>
    private void UseEarthBoulder() => UseBend($"{Path.Prefab}{GameObjectNames.EarthBoulder}");

    /// <summary>
    /// Use the Fire Stream Bending.
    /// </summary>
    private void UseFireStream() => UseBend($"{Path.Prefab}{GameObjectNames.FireStream}");

    /// <summary>
    /// Use the Water Whip Bending.
    /// </summary>
    private void UseWaterWhip() => UseBend($"{Path.Prefab}{GameObjectNames.WhaterWhip}");
}