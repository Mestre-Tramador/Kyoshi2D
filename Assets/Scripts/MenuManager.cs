using System.Collections;
using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;
using static MestreTramadorEMulherMotoca.Util.Helper;

/// <summary>
/// Manages and controls the Menu.
/// </summary>
public sealed class MenuManager : MonoBehaviour
{
    /// <summary>
    /// Determines if the Entrance has been played.
    /// </summary>
    /// <value><see cref="true"/> if the Entranche has ended.</value>
    private bool HasPlayedEntrance { get; set;}

    /// <summary>
    /// Give a little break and then switch the <see cref="Jukebox"/> disc to the Ambience.
    /// </summary>
    /// <returns>The <see cref="IEnumerator"/> of the Coroutine.</returns>
    private IEnumerator PlayAmbience()
    {
        yield return new WaitForSecondsRealtime(1.0f);

        Helper
        .GetJukebox()
        .ReplaceDiscOne(LoadResource<AudioClip>($"{Path.Music}{AudioClipNames.MenuAmbience}"))
        .SwitchDiscOneLoop()
        .PlayDiscOne();        
    }

    /// <summary>
    /// The Starter simply play the <see cref="Jukebox"/> disc 1.
    /// </summary>
    private void Start()
    {
        HasPlayedEntrance = false;

        Helper
        .GetJukebox()
        .PlayDiscOne();
    }

    /// <summary>
    /// The Updater listen to the end of the Entrance, to then play the Ambience.
    /// </summary>
    private void Update() // TODO: Improve method.
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneLoader.Load(SceneNames.PreBook, SceneData.BookEarth);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneLoader.Load(SceneNames.PreBook, SceneData.BookFire);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneLoader.Load(SceneNames.PreBook, SceneData.BookAir);
        }

        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneLoader.Load(SceneNames.PreBook, SceneData.BookWater);
        }

        if(!GetJukebox().IsDiscOnePlaying() && !HasPlayedEntrance)
        {
            HasPlayedEntrance = true;

            StartCoroutine(PlayAmbience());
        }
    }    
}
