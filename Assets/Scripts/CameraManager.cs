using UnityEngine;
using static MestreTramadorEMulherMotoca.Util.Helper;

/// <summary>
/// Manages and controls the Camera.
/// </summary>
public sealed class CameraManager : MonoBehaviour
{
    /// <summary>
    /// Determines if the Camera must follow the Player.
    /// </summary>
    /// <value><see cref="true"/> to follow the player.</value>
    public bool toFollow { get; private set; }

    /// <summary>
    /// The offset towards the Player, aka <see cref="Kyoshi"/>.
    /// </summary>
    /// <value>It's a Vector containing the difference of the Camera and the Player's positions.</value>
    private Vector3 Offset { get; set; }

    /// <summary>
    /// Start to follow.
    /// </summary>
    public void Follow() => toFollow = true;

    /// <summary>
    /// Manually update the position of the Camera.
    /// </summary>
    /// <param name="position">The new position.</param>
    public void ManualUpdate(Vector3 position) => StartCoroutine(MoveToPosition(gameObject, transform.position, position, 2.5f));

    /// <summary>
    /// Stop to follow.
    /// </summary>
    public void Unfollow() => toFollow = false;

    /// <summary>
    /// The Starter calculates and save the offset, also enables following.
    /// </summary>
    private void Start()
    {
        Offset = transform.position - GetKyoshi().transform.position;

        Follow();
    }

    /// <summary>
    /// On the Late Updater, the position is replaced to follow the Player, if.
    /// </summary>
    private void LateUpdate()
    {
        if(toFollow)
        {
            transform.position = GetKyoshi().transform.position + Offset;
        }
    }
}