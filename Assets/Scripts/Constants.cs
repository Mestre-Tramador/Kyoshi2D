using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MestreTramadorEMulherMotoca.Constants.Tags;

namespace MestreTramadorEMulherMotoca
{
    namespace Constants
    {
        public static class Tags
        {
            public const string Air = "Air";

            public const string Earth = "Earth";

            public const string Fire = "Fire";

            public const string Water = "Water";

            public const string Floor = "Floor";
        }

        public static class Player
        {
            public const float Speed = 5.0f;

            public const float JumpForce = 200.0f;

            public const float DashForce = 300.0f;
        }

        public static class Resources
        {
            public const string Cursor = "Cursor";

            public const string CursorAir = Cursor + Air;

            public const string CursorEarth = Cursor + Earth;

            public const string CursorFire = Cursor + Fire;

            public const string CursorWater = Cursor + Water;
        }

        public static class GameObjects
        {
            public const string AirBall = Air + "Ball";

            public const string EarthBoulder = Earth + "Boulder";

            public const string FireStream = Fire + "Stream";

            public const string Player = "Kyoshi";

            public const string WhaterWhip = Water + "Whip";
        }
    }
}
