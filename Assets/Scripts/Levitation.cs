using System.Collections;
using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using static MestreTramadorEMulherMotoca.Util.Helper;

/// <summary>
/// The Levitation is a rare ability. <br/>
///
/// Avatar <see cref="Kyoshi"/> dominates this technique.
/// </summary>
public class Levitation : MonoBehaviour
{
    /// <summary>
    /// The point on the Floor to return.
    /// </summary>
    /// <value>This vector is mixed with the Floor and the player positions.</value>
    public Vector3 PointToReturn { get; private set; }

    /// <summary>
    /// Mark the current Floor to return.
    /// </summary>
    /// <value>If some Floor was touched, then its instance is stored.</value>
    private GameObject CurrentFloor { get; set; }

    /// <summary>
    /// The routine gently disables the controls of the player to move it up,
    /// then on the direction of the Rescue Point and finally dropping it and returning the controls.
    /// </summary>
    public void Rescue()
    {
        StartCoroutine(Levitate());

        IEnumerator Levitate()
        {
            GetKyoshi().DisableMovement();

            GetPlayerComponent<Rigidbody2D>().isKinematic = true;

            GetJukebox().PlayDisc(DiscIndex.Dash);

            GetKyoshi().SetLevitatingAnimation(true);

            yield return StartCoroutine(MovePlayerToPosition(new Vector3(
                GetPlayer().transform.position.x,
                (PointToReturn.y + 0.5f),
                GetPlayer().transform.position.z
            )));

            GetJukebox().PlayDisc(DiscIndex.Dash);

            yield return StartCoroutine(MovePlayerToPosition(new Vector3(
                PointToReturn.x,
                GetPlayer().transform.position.y,
                GetPlayer().transform.position.z
            )));

            GetKyoshi().SetLevitatingAnimation(false);

            GetPlayerComponent<Rigidbody2D>().isKinematic = false;

            GetJukebox().PlayDisc(DiscIndex.DoubleJump);

            GetKyoshi().EnableMovement();
        }
    }

    /// <summary>
    /// On the Collision Enter, if is with an Abyss, then the player is rescued. <br/>
    ///
    /// Else, if it is a Return Point from a different Floor (or if
    /// none <see cref="CurrentFloor"/> is stored), then the <see cref="PointToReturn"/> is setted.
    /// </summary>
    /// <param name="other">The collider which had collided.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag(Tags.Abyss))
        {
            Rescue();

            return;
        }

        if(other.gameObject.CompareTag(Tags.Return) && (CurrentFloor is null || !CurrentFloor.Equals(other.gameObject)))
        {
            CurrentFloor = other.gameObject;

            PointToReturn = new Vector3(
                other.transform.position.x,
                GetPlayer().transform.position.y,
                GetPlayer().transform.position.z
            );
        }
    }
}