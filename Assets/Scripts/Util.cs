using UnityEngine;
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
            public static void SetAir() => Set(LoadResource<Texture2D>($"{Path.Cursor}{Constants.Resources.CursorAir}"));

            /// <summary>
            /// Set the Cursor to the Default theme.
            /// </summary>
            public static void SetDefault() => Set(LoadResource<Texture2D>($"{Path.Cursor}{Constants.Resources.Cursor}"));

            /// <summary>
            /// Set the Cursor to the Earth theme.
            /// </summary>
            public static void SetEarth() => Set(LoadResource<Texture2D>($"{Path.Cursor}{Constants.Resources.CursorEarth}"));

            /// <summary>
            /// Set the Cursor to the Fire theme.
            /// </summary>
            public static void SetFire() => Set(LoadResource<Texture2D>($"{Path.Cursor}{Constants.Resources.CursorFire}"));

            /// <summary>
            /// Set the Cursor to the Water theme.
            /// </summary>
            public static void SetWater() => Set(LoadResource<Texture2D>($"{Path.Cursor}{Constants.Resources.CursorWater}"));

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
            /// Get the Player main Component.
            /// </summary>
            /// <returns>The Kyoshi Component on its current state.</returns>
            public static Kyoshi GetKyoshi() => GetPlayer().GetComponent<Kyoshi>();

            /// <summary>
            /// Get the Player GameObject.
            /// </summary>
            /// <returns>The GameObject on its current state.</returns>
            public static GameObject GetPlayer() => GameObject.Find(Constants.GameObjects.Player);

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
            /// "Prefab" folder path.
            /// </summary>
            public const string Prefab = "Prefab/";
        }
    }
}