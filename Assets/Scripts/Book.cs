using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using MestreTramadorEMulherMotoca.Constants;
using static MestreTramadorEMulherMotoca.Constants.Lang;
using MestreTramadorEMulherMotoca.Util;
using static MestreTramadorEMulherMotoca.Util.Helper;
using SimpleJSON;

/// <summary>
/// Manages the Books Loading Screens.
/// </summary>
public sealed class Book : MonoBehaviour
{
    /// <summary>
    /// The Index of the <see cref="Book"/>, which determinate its texts.
    /// </summary>
    /// <value>An Integer as a String.</value>
    private string Index { get; set; }

    /// <summary>
    /// All the entries of the <see cref="Book"/> are stored in a JSON file.
    /// </summary>
    /// <value>
    /// The Data mostly contains all the entries above the key
    /// <see langword="BOOKS"/> and the <see cref="Index"/>
    /// </value>
    private JSONNode Data { get; set; }

    /// <summary>
    /// Gradually switch from the black screen color to white.
    /// </summary>
    /// <returns>The <see cref="IEnumerator"/> of the Coroutine.</returns>
    private IEnumerator Entrance()
    {
        for(float i = 0.0f; i <= 10.0f; i += Time.deltaTime)
        {
            Background().color = new Color(i, i, i);

            yield return null;
        }
    }

    /// <summary>
    /// Gradually switch from the white screen color to black.
    /// </summary>
    /// <returns>The <see cref="IEnumerator"/> of the Coroutine.</returns>
    private IEnumerator Disappearance()
    {
        for(float i = 5.0f; i >= 0.0f; i -= Time.deltaTime)
        {
            Background().color = new Color(i, i, i);

            yield return null;
        }
    }

    /// <summary>
    /// Present all the elements on the screen, fading in and fading out them gradually.
    /// </summary>
    /// <returns>The <see cref="IEnumerator"/> of the Coroutine.</returns>
    private IEnumerator Present()
    {
        BendCursor.Hide();

        GetJukebox().PlayDiscOne();

        yield return new WaitForSecondsRealtime(1.0f);

        StartCoroutine(Entrance());

        yield return new WaitForSecondsRealtime(2.0f);

        StartCoroutine(FadeIn(Symbol()));

        yield return new WaitForSecondsRealtime(0.5f);

        StartCoroutine(FadeIn(Label()));

        StartCoroutine(FadeIn(Number()));

        yield return new WaitForSecondsRealtime(3.5f);

        StartCoroutine(FadeIn(Title()));

        yield return new WaitForSecondsRealtime(4.0f);

        GetJukebox().PlayDisc(1);

        StartCoroutine(FadeIn(Subtitle()));

        yield return new WaitForSecondsRealtime(10.0f);

        yield return StartCoroutine(Disappearance());

        LoadBook();
    }

    /// <summary>
    /// The <see cref="Book"/> Background.
    /// </summary>
    /// <returns>The Image component of the Canvas child.</returns>
    private Image Background() => GameObject.Find(GameObjectNames.Background).GetComponent<Image>();

    /// <summary>
    /// The <see cref="Book"/> Symbol.
    /// </summary>
    /// <returns>The Image component of the Canvas child.</returns>
    private Image Symbol() => GameObject.Find(GameObjectNames.Symbol).GetComponent<Image>();

    /// <summary>
    /// The <see cref="Book"/> Label.
    /// </summary>
    /// <returns>The Text component of the Canvas child.</returns>
    private Text Label() => GameObject.Find(GameObjectNames.Label).GetComponent<Text>();

    /// <summary>
    /// The <see cref="Book"/> Number.
    /// </summary>
    /// <returns>The Text component of the Canvas child.</returns>
    private Text Number() => GameObject.Find(GameObjectNames.Number).GetComponent<Text>();

    /// <summary>
    /// The <see cref="Book"/> Subtitle.
    /// </summary>
    /// <returns>The Text component of the Canvas child.</returns>
    private Text Subtitle() => GameObject.Find(GameObjectNames.Subtitle).GetComponent<Text>();

    /// <summary>
    /// The <see cref="Book"/> Title.
    /// </summary>
    /// <returns>The Text component of the Canvas child.</returns>
    private Text Title() => GameObject.Find(GameObjectNames.Title).GetComponent<Text>();

    /// <summary>
    /// Get the current Language JSON file and parse it, storing its contents.
    /// </summary>
    private void GetData()
    {
        TextAsset lang = LoadResource<TextAsset>($"{Path.Lang}{CurrentLang()}");

        Data = JSON.Parse(lang.ToString());
    }

    /// <summary>
    /// Get the <see langword="Book"/> Scene parameter and store it. <br/>
    ///
    /// If unable to load the parameter, then an Exception is thrown.
    /// </summary>
    private void GetIndex()
    {
        Index = SceneLoader.Get("Book");

        if(Index.Length == 0)
        {
            throw new System.Exception("Unable to load scene!");
        }
    }

    /// <summary>
    /// Load the respective Elemental Book
    /// </summary>
    private void LoadBook()
    {
        SceneLoader.Load(SceneName());

        string SceneName()
        {
            switch(int.Parse(Index))
            {
                case 1: return SceneNames.BookEarth;

                case 2: return SceneNames.BookFire;

                case 3: return SceneNames.BookAir;

                case 4: return SceneNames.BookWater;

                default: return "";
            }
        }
    }

    /// <summary>
    /// The Starter firstly loads all data,
    /// then, with it, place all the respective
    /// assets on the screen and starts the fading routines.
    /// </summary>
    private void Start()
    {
        GetIndex();
        GetData();

        SetChant();
        SetSymbol();
        SetTexts();

        StartCoroutine(Present());
    }

    /// <summary>
    /// Set the Chant <see cref="AudioClip"/> to the <see cref="Jukebox"/>.
    /// </summary>
    private void SetChant()
    {
        GetJukebox().AddDisc(LoadResource<AudioClip>(ChantPath()));

        string ChantPath()
        {
            switch(int.Parse(Index))
            {
                case 1: return $"{Path.SFX}{AudioClipNames.BookChantEarth}";

                case 2: return $"{Path.SFX}{AudioClipNames.BookChantFire}";

                case 3: return $"{Path.SFX}{AudioClipNames.BookChantAir}";

                case 4: return $"{Path.SFX}{AudioClipNames.BookChantWater}";

                default: return "";
            }
        }
    }

    /// <summary>
    /// According to the <see cref="Index"/>, load the Symbol.
    /// </summary>
    private void SetSymbol()
    {
        Symbol().sprite = LoadResource<Sprite>(SymbolPath());

        string SymbolPath()
        {
            switch(int.Parse(Index))
            {
                case 1: return $"{Path.Nations}{ResourceNames.NationsEarth}";

                case 2: return $"{Path.Nations}{ResourceNames.NationsFire}";

                case 3: return $"{Path.Nations}{ResourceNames.NationsAir}";

                case 4: return $"{Path.Nations}{ResourceNames.NationsWater}";

                default: return "";
            }
        }
    }

    /// <summary>
    /// According to the <see cref="Index"/>, load each and every Texts. <br/>
    ///
    /// Depending on the <see cref="Index"/>, some positions are fixed.
    /// </summary>
    private void SetTexts()
    {
        Label().text    = Data[Books.ToString()][Index][Books.Label].Value;
        Title().text    = Data[Books.ToString()][Index][Books.Title].Value;
        Subtitle().text = Data[Books.ToString()][Index][Books.Subtitle].Value;
        Number().text   = Data[Books.ToString()][Index][Books.Number].Value + ":";

        switch(int.Parse(Index))
        {
            case 1:
            break;

            case 2:
            break;

            case 3:
            case 4:
                Label().rectTransform.anchoredPosition = new Vector2(-45.0f, Label().rectTransform.anchoredPosition.y);
                Number().rectTransform.anchoredPosition = new Vector2(40.0f, Number().rectTransform.anchoredPosition.y);
            break;
        }

    }
}