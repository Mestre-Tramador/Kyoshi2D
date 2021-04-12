using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;
using static MestreTramadorEMulherMotoca.Util.Helper;

/// <summary>
/// Marks the ends of each and every Book.
/// </summary>
public sealed class BookEnd : MonoBehaviour
{
    /// <summary>
    /// The ending scene of the Earth Book.
    /// </summary>
    public void EndEarthBook()
    {     
        const float playerX = 105.0f;

        StartCoroutine(MovePlayerToPosition(new Vector2(playerX, GetPlayer().transform.position.y), 30.0f));

        CloseCurtains();
    }

    /// <summary>
    /// Close the <see cref="Curtains"/>.
    /// </summary>
    private void CloseCurtains() => GameObject.Find(GameObjectNames.Curtains).GetComponent<Curtains>().Close();

    /// <summary>
    /// On the Enter Trigger, if the Player activated it,
    /// then the Book index is getted and the finalizations are prepared.
    /// </summary>
    /// <param name="other">The collider which had triggered.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.Equals(GetPlayer()))
        {
            if(int.TryParse(SceneLoader.Get("Book"), out int index))
            {
                switch(index)
                {
                    case 1:
                        const float cameraX = 70.0f;
                        const float cameraZ = -10.0f;

                        const float playerX = 58.0f;

                        GetCameraManager().Unfollow();
                        GetCameraManager().ManualUpdate(new Vector3(cameraX, GetCamera().transform.position.y, cameraZ));

                        GetKyoshi().DisableMovement();
                        
                        StartCoroutine(MovePlayerToPosition(new Vector2(playerX, GetPlayer().transform.position.y)));
                    break;
                }
            }
        }
    }
}
