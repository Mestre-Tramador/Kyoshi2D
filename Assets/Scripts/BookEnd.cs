using System.Collections;
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

        StartCoroutine(MovePlayerWalkingToPosition(new Vector2(playerX, GetPlayer().transform.position.y), 30.0f));

        CloseCurtains();
    }

    /// <summary>
    /// The ending scene of the Fire Book.
    /// </summary>
    public void EndFireBook()
    {
        StartCoroutine(DelayToEnd());

        IEnumerator DelayToEnd()
        {
            yield return new WaitForSecondsRealtime(4.0f);

            GetCameraManager().ManualUpdate(new Vector3(
                GetCamera().transform.position.x,
                GetCamera().transform.position.y + 10.0f,
                GetCamera().transform.position.z
            ));

            CloseCurtains();
        }
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
                const float cameraZ = -10.0f;

                float cameraX = 0.0f;
                float playerX = 0.0f;

                switch(index)
                {
                    case 1:
                        cameraX = 70.0f;
                        playerX = 58.0f;
                    break;

                    case 2:
                        cameraX = 47.5f;
                        playerX = 37.25f;
                    break;
                }

                GetCameraManager().Unfollow();
                GetCameraManager().ManualUpdate(new Vector3(cameraX, GetCamera().transform.position.y, cameraZ));

                GetKyoshi().DisableMovement();

                StartCoroutine(MovePlayerWalkingToPosition(new Vector2(playerX, GetPlayer().transform.position.y)));
            }
        }
    }
}