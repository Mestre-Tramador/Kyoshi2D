using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static MestreTramadorEMulherMotoca.Util.Helper;

namespace MestreTramadorEMulherMotoca
{
    namespace Util
    {
        /// <summary>
        /// Utility functions to the <see cref="Cursor"/> change.
        /// </summary>
        public static class BendCursor
        {
            /// <summary>
            /// Hide the visibility of the Cursor.
            /// </summary>
            public static void Hide() => Cursor.visible = false;

            /// <summary>
            /// Set the Cursor to the Air theme.
            /// </summary>
            public static void SetAir() => Set(LoadResource<Texture2D>($"{Path.Cursor}{Constants.ResourceNames.CursorAir}"));

            /// <summary>
            /// Set the Cursor to the Default theme.
            /// </summary>
            public static void SetDefault() => Set(LoadResource<Texture2D>($"{Path.Cursor}{Constants.ResourceNames.Cursor}"));

            /// <summary>
            /// Set the Cursor to the Earth theme.
            /// </summary>
            public static void SetEarth() => Set(LoadResource<Texture2D>($"{Path.Cursor}{Constants.ResourceNames.CursorEarth}"));

            /// <summary>
            /// Set the Cursor to the Fire theme.
            /// </summary>
            public static void SetFire() => Set(LoadResource<Texture2D>($"{Path.Cursor}{Constants.ResourceNames.CursorFire}"));

            /// <summary>
            /// Set the Cursor to the Water theme.
            /// </summary>
            public static void SetWater() => Set(LoadResource<Texture2D>($"{Path.Cursor}{Constants.ResourceNames.CursorWater}"));

            /// <summary>
            /// Set the Cursor to a given element.
            /// </summary>
            /// <param name="element">Must be one of the acceptable tags to have any effect.</param>
            public static void Set(string element)
            {
                switch(element)
                {
                    case Constants.Tags.Air:
                        SetAir();
                    return;

                    case Constants.Tags.Earth:
                        SetEarth();
                    return;

                    case Constants.Tags.Fire:
                        SetFire();
                    return;

                    case Constants.Tags.Water:
                        SetWater();
                    return;

                    default:
                        SetDefault();
                    return;
                }
            }

            /// <summary>
            /// Unhide the visibility of the Cursor.
            /// </summary>
            public static void Unhide() => Cursor.visible = true;

            /// <summary>
            /// Overwrite of the <see cref="Cursor.SetCursor(Texture2D, Vector2, CursorMode)"/>
            /// method, to facilitate the implementation through the class.
            /// </summary>
            /// <param name="cursor">The texture of the Cursor.</param>
            private static void Set(Texture2D cursor) => Cursor.SetCursor(
                cursor,
                Vector2.zero,
                CursorMode.Auto
            );
        }

        /// <summary>
        /// Help functions to general use.
        /// </summary>
        public static class Helper
        {
            /// <summary>
            /// Get if the Game is currently paused.
            /// </summary>
            /// <returns><see cref="true"/> if it's paused by any means.</returns>
            public static bool GameIsPaused() => (Time.timeScale == 0);

            /// <summary>
            /// Get if the Game is currently resumed.
            /// </summary>
            /// <returns><see cref="true"/> if the game is in any state other than paused.</returns>
            public static bool GameIsResumed() => (Time.timeScale > 0);

            /// <summary>
            /// Get if there was any Mouse click on screen.
            /// </summary>
            /// <returns><see cref="true"/> if there was a click by the Mouse Zero, One and Two buttons.</returns>
            public static bool GetAnyMouseClick() => (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2));

            /// <summary>
            /// Get if a numeric value is between a minimum and a maximum.
            /// </summary>
            /// <param name="value">The base value.</param>
            /// <param name="min">The minimum value.</param>
            /// <param name="max">The maximum value.</param>
            /// <returns><see langword="true"/> if the value is between said values.</returns>
            public static bool IsBetween(float value, float min, float max) => (value >= min && value <= max);

            /// <summary>
            /// Get if the Player is touching any <see cref="Constants.Tags.Floor"/> Game Objects.
            /// </summary>
            /// <returns><see cref="true"/> if it is.</returns>
            public static bool IsPlayerTouchingFloor() => IsTouchingFloor(GetPlayer());

            /// <summary>
            /// Get if a <see cref="Character"/> is touching any <see cref="Constants.Tags.Floor"/> Game Objects.
            /// </summary>
            /// <param name="character">The GameObject of the character.</param>
            /// <returns><see cref="true"/> if it is.</returns>
            public static bool IsTouchingFloor(GameObject character)
            {
                foreach(GameObject floor in GameObject.FindGameObjectsWithTag(Constants.Tags.Floor))
                {
                    if(character.GetComponent<Rigidbody2D>().IsTouching(floor.GetComponent<Collider2D>()))
                    {
                        return true;
                    }
                }

                return false;
            }

            /// <summary>
            /// Verify if some GameObject is turned to the left.
            /// </summary>
            /// <param name="scale">The local scale of the GameObject.</param>
            /// <returns><see langword="true"/> if it is.</returns>
            public static bool IsTurnedToLeft(Vector3 scale) => (scale.x < 0);

            /// <summary>
            /// Verify if some GameObject is turned to the right.
            /// </summary>
            /// <param name="scale">The local scale of the GameObject.</param>
            /// <returns><see langword="true"/> if it is.</returns>
            public static bool IsTurnedToRight(Vector3 scale) => (scale.x > 0);

            /// <summary>
            /// Calculate the changing of position on X axis.
            /// </summary>
            /// <param name="axis">The first X axis position.</param>
            /// <param name="speed">The speed of the movement.</param>
            /// <returns>The new position on X axis in numeric value.</returns>
            public static float CalculateXPosition(float axis, float speed) => (axis * speed * Time.deltaTime);

            /// <summary>
            /// Get the current used lang from <see cref="PlayerPrefs"/>.
            /// </summary>
            /// <returns>The String holding the Lang.</returns>
            public static string CurrentLang() => Constants.ResourceNames.En; // TODO: Improve with the PlayerPrefs.

            /// <summary>
            /// Get the Player Tag.
            /// </summary>
            /// <returns>The current Tag selected.</returns>
            public static string GetPlayerTag() => GetPlayer().tag;

            /// <summary>
            /// The the Main Camera manager Component.
            /// </summary>
            /// <returns>The CameraManager Component on its current state.</returns>
            public static CameraManager GetCameraManager() => GetCamera().GetComponent<CameraManager>();

            /// <summary>
            /// Give a Color with fixed values.
            /// </summary>
            /// <param name="r">Red entry.</param>
            /// <param name="g">Green entry.</param>
            /// <param name="b">Blue entry.</param>
            /// <param name="a"><see langword="optional"/> Alpha entry.</param>
            /// <returns>The Color structure with its values fixed.</returns>
            public static Color ColorFixed(float r, float g, float b, float a = 255.0f) => new Color((r / 255.0f), (g / 255.0f), (b / 255.0f), (a / 255.0f));

            /// <summary>
            /// Turn a Color opaque.
            /// </summary>
            /// <param name="color">The color to be transformed.</param>
            /// <returns>The same color but opaque.</returns>
            public static Color ColorOpaque(Color color) => new Color(color.r, color.g, color.b, 1);

            /// <summary>
            /// Turn a Color transparent.
            /// </summary>
            /// <param name="color">The color to be transformed.</param>
            /// <returns>The same color but transparent.</returns>
            public static Color ColorTransparent(Color color) => new Color(color.r, color.g, color.b, 0);

            /// <summary>
            /// Get the Main Camera GameObject.
            /// </summary>
            /// <returns>The GameObject on its current state.</returns>
            public static GameObject GetCamera() => Camera.main.gameObject;

            /// <summary>
            /// Get the Player GameObject.
            /// </summary>
            /// <returns>The GameObject on its current state.</returns>
            public static GameObject GetPlayer() => GameObject.Find(Constants.GameObjectNames.Player);

            /// <summary>
            /// Fade a Canvas Element in.
            /// </summary>
            /// <param name="element">The Element to be faded.</param>
            /// <returns>The <see cref="IEnumerator"/> of the Coroutine.</returns>
            public static IEnumerator FadeIn(MaskableGraphic element)
            {
                for(float i = 0; i <= 1; i += Time.deltaTime)
                {
                    element.color = new Color(
                        element.color.r,
                        element.color.g,
                        element.color.b,
                        i
                    );

                    yield return null;
                }
            }

            /// <summary>
            /// Fade a Canvas Element out.
            /// </summary>
            /// <param name="element">The Element to be faded.</param>
            /// <returns>The <see cref="IEnumerator"/> of the Coroutine.</returns>
            public static IEnumerator FadeOut(MaskableGraphic element)
            {
                for(float i = 1; i >= 0; i -= Time.deltaTime)
                {
                    element.color =  new Color(
                        element.color.r,
                        element.color.g,
                        element.color.b,
                        i
                    );

                    yield return null;
                }
            }

            /// <summary>
            /// Directly moves the Player to the desired position.
            /// </summary>
            /// <param name="finalPosition">The position to go.</param>
            /// <param name="duration"><see langword="optional"/>, it serves as a delay value.</param>
            /// <returns>The <see cref="IEnumerator"/> of the Coroutine.</returns>
            public static IEnumerator MovePlayerToPosition(Vector3 finalPosition, float duration = 1.0f) => MoveToPosition(GetPlayer(), GetPlayer().transform.position, finalPosition, duration);

            /// <summary>
            /// Directly moves the Player to the desired position, but walking.
            /// </summary>
            /// <param name="finalPosition">The position to go.</param>
            /// <param name="duration"><see langword="optional"/>, it serves as a delay value.</param>
            /// <returns>The <see cref="IEnumerator"/> of the Coroutine.</returns>
            public static IEnumerator MovePlayerWalkingToPosition(Vector3 finalPosition, float duration = 1.0f)
            {
                Vector3 initialPosition = GetPlayer().transform.position;

                GetKyoshi().SetWalkingAnimation(true);

                for(float time = 0.0f; time < duration; time += Time.deltaTime)
                {
                    GetPlayer().transform.position = Vector3.Lerp(initialPosition, finalPosition, (time / duration));

                    if(!GetJukebox().IsDiscPlaying(Constants.DiscIndex.Move))
                    {
                        GetJukebox().PlayDisc(Constants.DiscIndex.Move);
                    }

                    yield return 0;
                }

                GetPlayer().transform.position = finalPosition;

                if(GetPlayer().transform.position.Equals(finalPosition))
                {
                    GetKyoshi().SetWalkingAnimation(false);
                }
            }

            /// <summary>
            /// Move a reference GameObject to a position.
            /// </summary>
            /// <param name="reference">The object to move.</param>
            /// <param name="init">The initial position.</param>
            /// <param name="end">The final position.</param>
            /// <param name="duration"><see langword="optional"/>, it serves as a delay value.</param>
            /// <returns>The <see cref="IEnumerator"/> of the Coroutine.</returns>
            public static IEnumerator MoveToPosition(GameObject reference, Vector3 init, Vector3 end, float duration = 1.0f)
            {
                for(float time = 0.0f; time < duration; time += Time.deltaTime)
                {
                    reference.transform.position = Vector3.Lerp(init, end, (time / duration));

                    yield return 0;
                }

                reference.transform.position = end;
            }

            /// <summary>
            /// Get the current Jukebox.
            /// </summary>
            /// <returns>The Jukebox Component of the namesake GameObject.</returns>
            public static Jukebox GetJukebox() => GameObject.Find(Constants.GameObjectNames.Jukebox).GetComponent<Jukebox>();

            /// <summary>
            /// Get the Player main Component.
            /// </summary>
            /// <returns>The Kyoshi Component on its current state.</returns>
            public static Kyoshi GetKyoshi() => GetPlayerComponent<Kyoshi>();

            /// <summary>
            /// Get a specific Component of the Player.
            /// </summary>
            /// <typeparam name="Type">A valid <see cref="UnityEngine.Component"/>.</typeparam>
            /// <returns>The Component, if present.</returns>
            public static Type GetPlayerComponent<Type>() where Type : Component => GetPlayer().GetComponent<Type>();

            /// <summary>
            /// Overwrite of the <see cref="UnityEngine.Resources.Load{T}(string)"/> method,
            /// to facilitate the implementation through the class.
            /// </summary>
            /// <param name="path">The <see cref="Path"/> of the Resource.</param>
            /// <typeparam name="Type">A valid <see cref="UnityEngine.Object"/>.</typeparam>
            /// <returns>The Resource loaded.</returns>
            public static Type LoadResource<Type>(string path) where Type : Object => Resources.Load<Type>(path);

            /// <summary>
            /// Quick converter of the Mouse Position to a Game coordinate.
            /// </summary>
            /// <returns>A Vector3 with the correct position.</returns>
            public static Vector3 CurrentMouseWorldPoint() => Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                1.0f
            ));

            /// <summary>
            /// Get the Player Position.
            /// </summary>
            /// <returns>The position Vector3 on its current state.</returns>
            public static Vector3 GetPlayerPosition() => GetPlayer().transform.position;

            /// <summary>
            /// Put the game on pause state.
            /// </summary>
            public static void PauseGame() => Time.timeScale = 0;

            /// <summary>
            /// Put the game on resume state.
            /// </summary>
            public static void ResumeGame() => Time.timeScale = 1;

            /// <summary>
            /// Switches between the pause and resume states of the game.
            /// </summary>
            public static void SwitchGameState()
            {
                if(GameIsResumed())
                {
                    PauseGame();
                }
                else
                {
                    ResumeGame();
                }
            }

            /// <summary>
            /// Turn a 2D GameObject to the opposite direction.
            /// </summary>
            /// <param name="gameObject">The game object to turn.</param>
            public static void Turn(GameObject gameObject)
            {
                gameObject.transform.localScale = new Vector3(
                    (gameObject.transform.localScale.x * -1.0f),
                    gameObject.transform.localScale.y,
                    gameObject.transform.localScale.z
                );

                if(gameObject.GetComponent<Rigidbody2D>())
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
            }
        }

        /// <summary>
        /// The Paths through the project.
        /// </summary>
        public static class Path
        {
            /// <summary>
            /// "Cursor" folder path.
            /// </summary>
            public const string Cursor = "Cursor/";

            /// <summary>
            /// "Lang" folder path.
            /// </summary>
            public const string Lang = "Lang/";

            /// <summary>
            /// "Music" folder path.
            /// </summary>
            public const string Music = "Music/";

            /// <summary>
            /// "Nations" folder path.
            /// </summary>
            public const string Nations = "Nations/";

            /// <summary>
            /// "Prefab" folder path.
            /// </summary>
            public const string Prefab = "Prefab/";

            /// <summary>
            /// "SFX" folder path.
            /// </summary>
            public const string SFX = "SFX/";
        }

        /// <summary>
        /// A Loader facilitator for the <see cref="UnityEngine.SceneManagement.Scene"/> instances. <br/>
        ///
        /// It can hold some <see langword="string"/> params between scenes.
        /// </summary>
        public static class SceneLoader
        {
            /// <summary>
            /// All parameters are stored on a Dictionary.
            /// </summary>
            /// <value>Every Key-Value pair stores an info to the loaded scene.</value>
            private static Dictionary<string, string> Data { get; set; }

            /// <summary>
            /// Get the data stored.
            /// </summary>
            /// <returns>The current Dictionary of data.</returns>
            public static Dictionary<string, string> Get()
            {
                return Data;
            }

            /// <summary>
            /// Clear and refresh all the data.
            /// </summary>
            public static void Clear()
            {
                Data = null;

                VerifyData();
            }

            /// <summary>
            /// Get the current loaded <see cref="UnityEngine.SceneManagement.Scene"/> name.
            /// </summary>
            /// <returns>The name of the scene, as it is.</returns>
            public static string Current() => SceneManager.GetActiveScene().name;

            /// <summary>
            /// Load a <see cref="UnityEngine.SceneManagement.Scene"/> by its name.
            /// </summary>
            /// <param name="sceneName">The name of the <see cref="UnityEngine.SceneManagement.Scene"/>.</param>
            public static void Load(string sceneName)
            {
                SceneManager.LoadScene(sceneName);
            }

            /// <summary>
            /// Load a <see cref="UnityEngine.SceneManagement.Scene"/> by its name. <br/>
            ///
            /// Also, pass a new dataset to be stored and recovered on the new load.
            /// </summary>
            /// <param name="sceneName">The name of the <see cref="UnityEngine.SceneManagement.Scene"/>.</param>
            /// <param name="data">A set of <see cref="Data"/> parameters.</param>
            public static void Load(string sceneName, Dictionary<string, string> data)
            {
                Data = data;

                Load(sceneName);
            }

            /// <summary>
            /// Load a <see cref="UnityEngine.SceneManagement.Scene"/> by its name. <br/>
            ///
            /// Also, pass any number of parameters to be stored and recovered on the new load.
            /// </summary>
            /// <param name="sceneName">The name of the <see cref="UnityEngine.SceneManagement.Scene"/>.</param>
            /// <param name="parameters">Every Kay-Value Pair to load on the new scene.</param>
            public static void Load(string sceneName, params KeyValuePair<string, string>[] parameters)
            {
                VerifyData();

                foreach(KeyValuePair<string, string> parameter in parameters)
                {
                    Set(parameter.Key, parameter.Value);
                }

                Load(sceneName);
            }

            /// <summary>
            /// Get a specific parameter.
            /// </summary>
            /// <param name="key">The key which holds the value.</param>
            /// <returns>An empty <see langword="string"/> or the value.</returns>
            public static string Get(string key)
            {
                VerifyData();

                if(Data.TryGetValue(key, out string parameter))
                {
                    switch(key)
                    {
                        case "Book": return (parameter != "" ? parameter : "0");

                        default: return parameter;
                    }
                }

                return "";
            }

            /// <summary>
            /// Set a value to a key and store them.
            /// </summary>
            /// <param name="key">The parameter key.</param>
            /// <param name="value">The parameter value.</param>
            public static void Set(string key, string value)
            {
                VerifyData();

                if(Data.TryGetValue(key, out string oldValue))
                {
                    Data[key] = value;

                    return;
                }

                Data.Add(key, value);
            }

            /// <summary>
            /// Set and store any number of Key-Value Pairs at once.
            /// </summary>
            /// <param name="parameters">The parameters to save.</param>
            public static void Set(params KeyValuePair<string, string>[] parameters)
            {
                foreach(KeyValuePair<string, string> parameter in parameters)
                {
                    Set(parameter.Key, parameter.Value);
                }
            }

            /// <summary>
            /// Simple verifier if there is a valid <see cref="Dictionary{TKey, TValue}"/>. <br/>
            ///
            /// If not, instantiate it.
            /// </summary>
            private static void VerifyData()
            {
                if(Data == null)
                {
                    Data = new Dictionary<string, string>();
                }
            }
        }
    }
}