using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;

/// <summary>
/// An Obstacle is an object on the map which needs to be solved.
/// </summary>
public class Obstacle : MonoBehaviour
{
    /// <summary>
    /// Simply destroy completely the Barrier, liberating the passage.
    /// </summary>
    protected void EndBarrier() => Destroy(GetBarrier());

    /// <summary>
    /// Provides the current Barrier.
    /// </summary>
    /// <returns>The Object serving as a Barrier.</returns>
    protected GameObject GetBarrier() => transform.Find(GameObjectNames.Barrier).gameObject;

    /// <summary>
    /// When placing something up and inside of a hole,
    /// the placing event is also naturally fired.
    /// </summary>
    /// <param name="placeable">The placed object.</param>
    protected virtual void OnHolePlace(GameObject placeable) => OnPlace();

    /// <summary>
    /// When filling the hole with someting, 
    /// the filling event is also naturally fired.
    /// </summary>
    protected virtual void OnHoleFill() => OnFill();

    /// <summary>
    /// On the Collision Enter, the collider is verified
    /// if it's a Bend or a Movable Bend, and if, the proper
    /// event is fired according to both name and tags.
    /// </summary>
    /// <param name="other">The collider which had collided.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.TryGetComponent<Bend>(out Bend bend))
        {
            switch(name)   
            {
                case GameObjectNames.Hole:                    
                    if(other.gameObject.CompareTag(Tags.Earth))
                    {
                        OnHoleFill();
                    }
                break;
            }

            return;
        }

        if(other.gameObject.TryGetComponent<Movable>(out Movable movable))
        {
            switch(name)   
            {
                case GameObjectNames.Hole:           
                    if(other.gameObject.CompareTag(Tags.Earth))
                    {
                        OnHolePlace(other.gameObject);
                    }
                break;
            }
        }
    }    

    /// <summary>
    /// The filling event,
    /// it simply mark as filled by removing collisions
    /// and end the Barrier.
    /// </summary>
    private void OnFill()
    {
        if(TryGetComponent<Collider2D>(out Collider2D collider))   
        {
            Destroy(collider);
        }

        EndBarrier();
    }

    /// <summary>
    /// The placeing event acts equally as a filling event.
    /// </summary>
    private void OnPlace() => OnFill(); 
}
