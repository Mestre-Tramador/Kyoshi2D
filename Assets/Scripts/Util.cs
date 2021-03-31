using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MestreTramadorEMulherMotoca.Util.Helper;

namespace MestreTramadorEMulherMotoca
{
    namespace Util
    {
        public static class Helper
        {
            public static float CalculateXPosition(float axis, float speed) => (axis * speed * Time.deltaTime);

            public static bool IsTurnedToLeft(Vector3 scale) => (scale.x < 0);

            public static bool IsTurnedToRight(Vector3 scale) => (scale.x > 0);

            public static void Turn(GameObject gameObject) => gameObject.transform.localScale = new Vector3(
                (gameObject.transform.localScale.x * -1.0f),
                gameObject.transform.localScale.y,
                gameObject.transform.localScale.z
            );

            public static Type LoadResource<Type>(string path) where Type : Object => Resources.Load<Type>(path);

            public static GameObject GetPlayer() => GameObject.Find(Constants.GameObjects.Player);
        }

        public static class BendCursor
        {
            public static void SetAir() => Set(LoadResource<Texture2D>($"{Path.Cursor}{Constants.Resources.CursorAir}"));

            public static void SetDefault() => Set(LoadResource<Texture2D>($"{Path.Cursor}{Constants.Resources.Cursor}"));

            public static void SetEarth() => Set(LoadResource<Texture2D>($"{Path.Cursor}{Constants.Resources.CursorEarth}"));

            public static void SetFire() => Set(LoadResource<Texture2D>($"{Path.Cursor}{Constants.Resources.CursorFire}"));

            public static void SetWater() => Set(LoadResource<Texture2D>($"{Path.Cursor}{Constants.Resources.CursorWater}"));

            public static void Set(string element)
            {
                switch(element)
                {
                    case Constants.Keys.Air:
                        SetAir();
                    return;

                    case Constants.Keys.Earth:
                        SetEarth();
                    return;

                    case Constants.Keys.Fire:
                        SetFire();
                    return;

                    case Constants.Keys.Water:
                        SetWater();
                    return;

                    default:
                        SetDefault();
                    return;
                }
            }

            private static void Set(Texture2D cursor) => Cursor.SetCursor(
                cursor,
                Vector2.zero,
                CursorMode.Auto
            );
        }

        public static class Path
        {
            public const string Cursor = "Cursor/";
        }
    }
}
