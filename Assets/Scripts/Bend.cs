using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;

/// <summary>
/// Represents a usable Bend.
/// </summary>
public class Bend : MonoBehaviour
{
    /// <summary>
    /// Dissipate the Bend, then destroy it.
    /// </summary>
    public void Dissipate()
    {
        Cursor.visible = true;

        Destroy(gameObject);
    }

    /// <summary>
    /// Make the Bend follow the <see cref="Cursor"/>.
    /// </summary>
    private void Follow()
    {
        transform.position = Vector2.Lerp(
            transform.position,
            Helper.CurrentMouseWorldPoint(),
            1.0f
        );
    }

    /// <summary>
    /// On the Enter Collider, the Bend is dissipated.
    /// </summary>
    /// <param name="collider">The collider wich had collided.</param>
    private void OnCollisionEnter2D(Collision2D collider)
    {
        Dissipate();
    }

    /// <summary>
    /// The Updater keeps the Bend following until the Mouse LButton is dropped.
    /// </summary>
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Follow();

            return;
        }

        if((CompareTag(Tags.Air) || CompareTag(Tags.Fire)) || !GetComponent<Renderer>().isVisible)
        {
            Dissipate();
        }
    }
}