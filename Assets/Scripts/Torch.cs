using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;
using static MestreTramadorEMulherMotoca.Util.Helper;

/// <summary>
/// A Torch is a variation of am Obstacle.
/// </summary>
public class Torch : Obstacle
{
    /// <summary>
    /// The Barrier of the Torch belongs to its parent, so it must be <see langword="override"/>.
    /// </summary>
    /// <returns>The Object serving as a Barrier.</returns>
    protected override GameObject GetBarrier() => transform.parent.Find(GameObjectNames.Barrier).gameObject;

    /// <summary>
    /// When a Torch is lightened up, it turns its fuel opaque and visible,
    /// also play its Jukebox disc and become <see cref="Bendable"/>. <br/>
    ///
    /// As an <see langword="override"/>, only the Torch have this behavior.
    /// </summary>
    protected override void OnTorchLightUp()
    {
        if(TryGetComponent<SpriteRenderer>(out SpriteRenderer sprite))
        {
            sprite.color = ColorOpaque(sprite.color);
        }

        GetJukebox().PlayDisc(DiscIndex.Obstacle);

        gameObject.AddComponent<Bendable>();

        base.OnTorchLightUp();
    }

    /// <summary>
    /// The Starter serves to set and load the Obstacle Jukebox disc.
    /// </summary>
    private void Start() => GetJukebox().AddDisc(DiscIndex.Obstacle, LoadResource<AudioClip>($"{Path.SFX}{AudioClipNames.ObstacleTorchLightUp}"));
}