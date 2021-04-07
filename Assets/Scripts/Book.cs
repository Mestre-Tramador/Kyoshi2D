using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using MestreTramadorEMulherMotoca.Constants;
using static MestreTramadorEMulherMotoca.Constants.Lang;
using MestreTramadorEMulherMotoca.Util;
using SimpleJSON;

/// <summary>
/// Manages the Books Loading Screens.
/// </summary>
public sealed class Book : MonoBehaviour
{
    /// <summary>
    /// The Index of the <see cref="Book"/>, wich determinates its texts.
    /// </summary>
    /// <value>An Integer as a String.</value>
    private string Index { get; set; }

    /// <summary>
    /// All the entrys of the <see cref="Book"/> are stored in a JSON file.
    /// </summary>
    /// <value>
    /// The Data mostly contains all the entries above the key
    /// <see langword="BOOKS"/> and the <see cref="Index"/>
    /// </value>
    private JSONNode Data { get; set; }

    /// <summary>
    /// Gradualy switch from the black screen color to white.
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
    /// Gradualy switch from the white screen color to black.
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
    /// Present all the elements on the screen, fading in and fading out them gradualy.
    /// </summary>
    /// <returns>The <see cref="IEnumerator"/> of the Coroutine.</returns>
    private IEnumerator Present()
    {
        BendCursor.Hide();

        Helper.GetJukebox().PlayDiscOne();

        yield return new WaitForSecondsRealtime(1.0f);

        StartCoroutine(Entrance());

        yield return new WaitForSecondsRealtime(2.0f);

        StartCoroutine(Helper.FadeIn(Symbol()));

        yield return new WaitForSecondsRealtime(0.5f);

        StartCoroutine(Helper.FadeIn(Label()));

        StartCoroutine(Helper.FadeIn(Number()));

        yield return new WaitForSecondsRealtime(3.5f);

        StartCoroutine(Helper.FadeIn(Title()));

        yield return new WaitForSecondsRealtime(4.0f);

        Helper.GetJukebox().PlayDisc(1);

        StartCoroutine(Helper.FadeIn(Subtitle()));

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
        TextAsset lang = Helper.LoadResource<TextAsset>($"{Path.Lang}{Helper.CurrentLang()}");

        Data = JSON.Parse(lang.ToString());
    }

    /// <summary>
    /// Get the <see langword="Book"/> Scene parameter and store it. <br/>
    ///
    /// If unnable to load the parameter, then an Exception is thrown.
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
        string scene = "";

        switch(int.Parse(Index))
        {
            case 1:
                scene = SceneNames.BookEarth;
            break;

            case 2:
                scene = SceneNames.BookFire;
            break;

            case 3:
                scene = SceneNames.BookAir;
            break;

            case 4:
                scene = SceneNames.BookWater;
            break;
        }

        SceneLoader.Load(scene);
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
        string path = "";

        switch(int.Parse(Index))
        {
            case 1:
                path = $"{Path.SFX}{AudioClipNames.BookChantEarth}";
            break;

            case 2:
                path = $"{Path.SFX}{AudioClipNames.BookChantFire}";
            break;

            case 3:
                path = $"{Path.SFX}{AudioClipNames.BookChantAir}";
            break;

            case 4:
                path = $"{Path.SFX}{AudioClipNames.BookChantWater}";
            break;
        }

        Helper.GetJukebox().AddDisc(Helper.LoadResource<AudioClip>(path));
    }

    /// <summary>
    /// According to the <see cref="Index"/>, load the Symbol.
    /// </summary>
    private void SetSymbol()
    {
        string path = "";

        switch(int.Parse(Index))
        {
            case 1:
                path = $"{Path.Nations}{ResourceNames.NationsEarth}";
            break;

            case 2:
                path = $"{Path.Nations}{ResourceNames.NationsFire}";
            break;

            case 3:
                path = $"{Path.Nations}{ResourceNames.NationsAir}";
            break;

            case 4:
                path = $"{Path.Nations}{ResourceNames.NationsWater}";
            break;
        }

        Symbol().sprite = Helper.LoadResource<Sprite>(path);
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
