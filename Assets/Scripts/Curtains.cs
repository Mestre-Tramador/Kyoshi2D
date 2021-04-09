using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;

/// <summary>
/// The Curtains on every and each of the the Books.
/// </summary>
public sealed class Curtains : MonoBehaviour
{
    /// <summary>
    /// Opposite to the opening, the closure hides
    /// the Book and loads the next one on a fade
    /// in black screen.
    /// </summary>
    public void Close()
    {
        StartCoroutine(Closure());
        
        IEnumerator Closure()
        {
            Helper.GetKyoshi().PlaceBelow();

            yield return new WaitForSecondsRealtime(2.0f);

            BendCursor.Hide();            

            StartCoroutine(Helper.FadeIn(GetComponent<Image>()));

            yield return new WaitForSecondsRealtime(1.0f);

            LoadNext();
        }
    }

    /// <summary>
    /// Await to open the Curtains and reveal the Book.
    /// </summary>
    /// <returns>The <see cref="IEnumerator"/> of the Coroutine.</returns>
    private IEnumerator AwaitToFadeOut()
    {
        yield return new WaitForSecondsRealtime(1.0f);

        StartCoroutine(Helper.FadeOut(GetComponent<Image>()));

        yield return new WaitForSecondsRealtime(1.0f);

        BendCursor.Unhide();

        Helper.GetKyoshi().PlaceAbove();
    }

    /// <summary>
    /// Get the current Book and load the next.
    /// </summary>
    private void LoadNext()
    {
        int next = int.Parse(SceneLoader.Get("Book"));
        next++;

        if(next > 4)
        {
            SceneLoader.Load(SceneNames.Menu);
            
            return;
        }

        SceneLoader.Load(SceneNames.PreBook, new KeyValuePair<string, string>("Book", next.ToString()));
    }

    /// <summary>
    /// The Starter simply await until fade out.
    /// </summary>
    private void Start() => StartCoroutine(AwaitToFadeOut());
}
