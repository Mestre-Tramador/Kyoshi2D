using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;
using static MestreTramadorEMulherMotoca.Util.Helper;

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
        if(GameIsResumed())
        {
            BendCursor.Unhide();
        }

        Destroy(gameObject);
    }

    /// <summary>
    /// Get if the Bend is of a physical element.
    /// </summary>
    /// <returns><see langword="true"/> if is a Bend of Earth or Water.</returns>
    private bool IsAPhysicalElement() => (CompareTag(Tags.Earth) || CompareTag(Tags.Water));

    /// <summary>
    /// Get if the Bend is not a physical element.
    /// </summary>
    /// <returns><see langword="true"/> if is a Bend of Air or Fire.</returns>
    private bool IsNotAPhysicalElement() => (!IsAPhysicalElement());

    /// <summary>
    /// Make the Bend follow the <see cref="Cursor"/>.
    /// </summary>
    private void Follow() => transform.position = Vector2.Lerp(transform.position, CurrentMouseWorldPoint(), 1.0f);

    /// <summary>
    /// On the Enter Collider, the Bend is dissipated if
    /// is not in contact with a Barrier.
    /// </summary>
    /// <param name="other">The collider which had collided.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag(Tags.Barrier))
        {
            return;
        }

        Dissipate();
    }

    /// <summary>
    /// The Destroyer play the last Dissipate disc on the Jukebox
    /// and stop the Bend disc if it's playing.
    /// </summary>
    private void OnDestroy()
    {
        if(GetJukebox().IsDiscPlaying(DiscIndex.Bend))
        {
            GetJukebox().StopDisc(DiscIndex.Bend);
        }

        GetJukebox().PlayDisc(DiscIndex.Dissipate);
    }

    /// <summary>
    /// The Starter set the Bend and Dissipate discs on the Jukebox,
    /// also play the first one.
    /// </summary>
    private void Start()
    {
        Helper
        .GetJukebox()
        .AddDisc(DiscIndex.Bend, GetBendDisc())
        .AddDisc(DiscIndex.Dissipate, GetDissipateDisc())
        .PlayDisc(DiscIndex.Bend);

        AudioClip GetDissipateDisc()
        {
            switch(tag)
            {
                case Tags.Earth: return LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.EarthBend}");

                case Tags.Fire: return LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.FireEnd}");

                default: return null;
            }
        }

        AudioClip GetBendDisc()
        {
            switch(tag)
            {
                case Tags.Earth: return LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.EarthBend}");

                case Tags.Fire: return LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.FireBendStart}");

                default: return null;
            }
        }
    }

    /// <summary>
    /// The Updater keeps the Bend following until the Mouse LButton is dropped.
    /// </summary>
    private void Update()
    {
        if(Input.GetMouseButton(0) && GameIsResumed() && !HasDropped)
        {
            Follow();

            if(IsNotAPhysicalElement() && !GetJukebox().IsDiscPlaying(DiscIndex.Bend))
            {
                GetJukebox()
                .ReplaceDisc(DiscIndex.Bend, GetNonPhysicalBendDisc())
                .PlayDiscIfNotPlaying(DiscIndex.Bend);
            }

            return;
        }

        HasDropped = true;

        if(IsNotAPhysicalElement() || !GetComponent<Renderer>().isVisible || GameIsPaused())
        {
            Dissipate();
        }

        AudioClip GetNonPhysicalBendDisc() => (CompareTag(Tags.Fire) ? LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.FireBend}") : null);
    }
}