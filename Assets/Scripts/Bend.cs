using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;

/// <summary>
/// Represents a usable Bend.
/// </summary>
public sealed class Bend : MonoBehaviour
{
    /// <summary>
    /// Determine if the Bend has been dropped.
    /// </summary>
    /// <value><see langword="true"/> if it has been dropped, aka the mouse button lifted.</value>
    private bool HasDropped { get; set; } = false;

    /// <summary>
    /// Dissipate the Bend, then destroy it.
    /// </summary>
    public void Dissipate()
    {
        if(Helper.GameIsResumed())
        {
            BendCursor.Unhide();
        }

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
    /// On the Enter Collider, the Bend is dissipated if
    /// is not in contact with a Barrier.
    /// </summary>
    /// <param name="other">The collider wich had collided.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(!other.gameObject.CompareTag(Tags.Barrier))
        {
            Dissipate();
        }
    }

    /// <summary>
    /// The Destroyer play the last Dissipate disc on the Jukebox.
    /// </summary>
    private void OnDestroy()
    {
        Helper.GetJukebox().PlayDisc(DiscIndex.Dissipate);
    }

    /// <summary>
    /// The Starter set the Pull and Dissipate discs on the Jukebox,
    /// also play the first one.
    /// </summary>
    private void Start()
    {
        Helper
        .GetJukebox()
        .AddDisc(
            DiscIndex.Pull,
            Helper.LoadResource<AudioClip>(PullPath())
        )
        .AddDisc(
            DiscIndex.Dissipate,
            Helper.LoadResource<AudioClip>(DissipatePath())
        )
        .PlayDisc(DiscIndex.Pull);

        string DissipatePath()
        {
            switch(tag)
            {
                case Tags.Earth:
                return $"{Path.SFX}{AudioClipNames.EarthImpact}";

                default:
                return "";
            }
        }

        string PullPath()
        {
            switch(tag)
            {
                case Tags.Earth:
                return $"{Path.SFX}{AudioClipNames.EarthPull}";

                default:
                return "";
            }
        }
    }

    /// <summary>
    /// The Updater keeps the Bend following until the Mouse LButton is dropped.
    /// </summary>
    private void Update()
    {
        if(Input.GetMouseButton(0) && Helper.GameIsResumed() && !HasDropped)
        {
            Follow();

            return;
        }

        HasDropped = true;

        if((CompareTag(Tags.Air) || CompareTag(Tags.Fire)) || !GetComponent<Renderer>().isVisible || Helper.GameIsPaused())
        {
            Dissipate();
        }
    }
}