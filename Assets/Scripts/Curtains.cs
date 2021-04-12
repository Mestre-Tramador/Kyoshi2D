using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;
using static MestreTramadorEMulherMotoca.Util.Helper;

/// <summary>
/// The Curtains on every and each of the the Books.
/// </summary>
public sealed class Curtains : MonoBehaviour
{
    private bool IsClosing { get; set; }

    /// <summary>
    /// Opposite to the opening, the closure hides
    /// the Book and loads the next one on a fade
    /// in black screen.
    /// </summary>
    public void Close()
    {
        if(!IsClosing)
        {
            StartCoroutine(Closure());
        }
        
        IEnumerator Closure()
        {
            IsClosing = true;

            GetKyoshi().PlaceBelow();

            yield return new WaitForSecondsRealtime(2.0f);

            BendCursor.Hide();            

            StartCoroutine(FadeIn(GetComponent<Image>()));

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
        IsClosing = false;

        yield return new WaitForSecondsRealtime(1.0f);

        StartCoroutine(FadeOut(GetComponent<Image>()));

        yield return new WaitForSecondsRealtime(1.0f);

        BendCursor.Unhide();

        GetKyoshi().PlaceAbove();
    }

    /// <summary>
    /// Get the current Book and load the next.
    /// </summary>
    private void LoadNext()
    {
        int next = (int.TryParse(SceneLoader.Get("Book"), out int index) ? (index + 1) : 0);
                
        if(next > 4 || next == 0)
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
