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
        /// Utilitary functions to the <see cref="Cursor"/> change.
        /// </summary>
        public static class BendCursor
        {
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
            /// Overwrite of the <see cref="Cursor.SetCursor(Texture2D, Vector2, CursorMode)"/>
            /// method, to facilitate the implementation throught the class.
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
            /// Calculate the changing of position on X axis.
            /// </summary>
            /// <param name="axis">The first X axis position.</param>
            /// <param name="speed">The speed of the movement.</param>
            /// <returns>The new position on X axis in numeric value.</returns>
            public static float CalculateXPosition(float axis, float speed) => (axis * speed * Time.deltaTime);

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
            /// Get the current used lang from <see cref="PlayerPrefs"/>.
            /// </summary>
            /// <returns>The String holding the Lang.</returns>
            public static string CurrentLang() => Constants.ResourceNames.En; // TODO: Improve with the PlayerPrefs.
            
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
            /// Get the Player main Component.
            /// </summary>
            /// <returns>The Kyoshi Component on its current state.</returns>
            public static Kyoshi GetKyoshi() => GetPlayer().GetComponent<Kyoshi>();

            /// <summary>
            /// Get the Player GameObject.
            /// </summary>
            /// <returns>The GameObject on its current state.</returns>
            public static GameObject GetPlayer() => GameObject.Find(Constants.GameObjectNames.Player);

            /// <summary>
            /// Verifiy if some GameObject is turned to the left.
            /// </summary>
            /// <param name="scale">The local scale of the GameObject.</param>
            /// <returns><see langword="true"/> if it is.</returns>
            public static bool IsTurnedToLeft(Vector3 scale) => (scale.x < 0);

            /// <summary>
            /// Verifiy if some GameObject is turned to the right.
            /// </summary>
            /// <param name="scale">The local scale of the GameObject.</param>
            /// <returns><see langword="true"/> if it is.</returns>
            public static bool IsTurnedToRight(Vector3 scale) => (scale.x > 0);

            /// <summary>
            /// Ovewrite of the <see cref="UnityEngine.Resources.Load{T}(string)"/> method,
            /// to facilitate the implementation throught the class.
            /// </summary>
            /// <param name="path">The <see cref="Path"/> of the Resource.</param>
            /// <typeparam name="Type">A valid <see cref="UnityEngine.Object"/>.</typeparam>
            /// <returns>The Resource loaded.</returns>
            public static Type LoadResource<Type>(string path) where Type : Object => Resources.Load<Type>(path);

            /// <summary>
            /// Turn a 2D GameObject to the oposite direction.
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
        /// The Paths throughts the project.
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
            /// "Nations" folder path.
            /// </summary>
            public const string Nations = "Nations/";

            /// <summary>
            /// "Prefab" folder path.
            /// </summary>
            public const string Prefab = "Prefab/";
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
                    Data.Add(parameter.Key, parameter.Value);
                }

                Load(sceneName);
            }            

            /// <summary>
            /// Get a specific parameter.
            /// </summary>
            /// <param name="key">The key wich holds the value.</param>
            /// <returns>An empty <see langword="string"/> or the value.</returns>
            public static string Get(string key)
            {                     
                if(Data != null)         
                {
                    if(Data.TryGetValue(key, out string parameter)) 
                    {
                        return parameter;
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