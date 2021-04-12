using UnityEngine;
using static MestreTramadorEMulherMotoca.Util.Helper;

/// <summary>
/// A Hole is a variation of a Obstacle.
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
        Debug.Log("A MORTE DO BUIACO!!!!");

        transform.Find("Fillable").GetComponent<SpriteRenderer>().color = ColorFixed(27.0f, 84.0f, 42.0f);

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
        Debug.Log("O PREENCHIMENTO DO BUIACO!!!!");
        
        if(placeable.TryGetComponent<Movable>(out Movable bend)) 
        {
            bend.MakeUnbendable();
        }

        placeable.transform.position = new Vector3(transform.position.x + 1.5f, 0.0f, 0.0f);
        // placeable.GetComponent<SpriteRenderer>().flipY = true;

        // transform.Find("Fillable").GetComponent<SpriteRenderer>().color = ColorFixed(27.0f, 84.0f, 42.0f);
        Destroy(transform.Find("Fillable").GetComponent<SpriteRenderer>());
        
        base.OnHolePlace(placeable);
    }
}
