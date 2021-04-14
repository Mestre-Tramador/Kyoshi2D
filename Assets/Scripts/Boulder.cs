using UnityEngine;

/// <summary>
/// A Boulder is a variation of a Obstacle.
/// </summary>
public class Boulder : Obstacle
{
    /// <summary>
    /// When a Boulder is placed, it assumes the position designed
    /// and become unbendable. <br/>
    ///
    /// As an <see langword="override"/>, only the Boulder have this behavior.
    /// </summary>
    /// <param name="boulder">The placed boulder.</param>
    protected override void OnBoulderPlace(GameObject boulder)
    {
        boulder.transform.position = transform.position;

        if(boulder.TryGetComponent<Movable>(out Movable bend))
        {
           bend.MakeUnbendable();
        }

        base.OnBoulderPlace(boulder);
    }
}