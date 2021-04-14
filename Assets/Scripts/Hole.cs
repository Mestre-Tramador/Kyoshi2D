using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using static MestreTramadorEMulherMotoca.Util.Helper;

/// <summary>
/// A Hole is a variation of an Obstacle.
/// </summary>
public sealed class Hole : Obstacle
{
    /// <summary>
    /// When a Hole is filled, it... <br/>
    ///
    /// As an <see langword="override"/>, only the Hole have this behavior.
    /// </summary>
    protected override void OnHoleFill()
    {
        GetHoleFillable().GetComponent<SpriteRenderer>().color = ColorFixed(27.0f, 84.0f, 42.0f);

        base.OnHoleFill();
    }

    /// <summary>
    /// When something is placed in a Hole, it... <br/>
    ///
    /// As an <see langword="override"/>, only the Hole have this behavior.
    /// </summary>
    /// <param name="placeable">The placed object.</param>
    protected override void OnHolePlace(GameObject placeable)
    {
        placeable.transform.position = new Vector3(transform.position.x + 1.5f, 0.0f, 0.0f);

        placeable.GetComponent<Movable>().MakeUnbendable();

        Destroy(GetHoleFillable().GetComponent<SpriteRenderer>());

        base.OnHolePlace(placeable);
    }

    /// <summary>
    /// Find and get the Hole Fillable.
    /// </summary>
    /// <returns>The child <see cref="GameObject"/>.</returns>
    private GameObject GetHoleFillable() => transform.Find(GameObjectNames.Fillable).gameObject;
}