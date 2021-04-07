using UnityEngine;
using MestreTramadorEMulherMotoca.Util;

/// <summary>
/// Manages and controls the Camera.
/// </summary>
public sealed class CameraManager : MonoBehaviour
{
    /// <summary>
    /// The offset towards the Player, aka <see cref="Kyoshi"/>.
    /// </summary>
    /// <value>It's a Vector containing the difference of the Camera and the Player's positions.</value>
    private Vector3 Offset { get; set; }

    /// <summary>
    /// The Starter calculates and save the offset.
    /// </summary>
    private void Start()
    {
        Offset = transform.position - Helper.GetKyoshi().transform.position;
    }

    /// <summary>
    /// On the Late Updates, the position is replaced to follow the Player.
    /// </summary>
    private void LateUpdate()
    {
        transform.position = Helper.GetKyoshi().transform.position + Offset;
    }
}
