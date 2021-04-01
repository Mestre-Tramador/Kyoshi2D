using static MestreTramadorEMulherMotoca.Constants.Tags;

namespace MestreTramadorEMulherMotoca
{
    namespace Constants
    {
        /// <summary>
        /// The Contants names for <see cref="UnityEngine.GameObject"/> instances.
        /// </summary>
        public static class GameObjects
        {
            /// <summary>
            /// The Air Ball Bend.
            /// </summary>
            public const string AirBall = Air + "Ball";

            /// <summary>
            /// The Earth Boulder Bend.
            /// </summary>
            public const string EarthBoulder = Earth + "Boulder";

            /// <summary>
            /// The Fire Stream Bend.
            /// </summary>
            public const string FireStream = Fire + "Stream";

            /// <summary>
            /// The Player, aka, <see cref="Kyoshi"/>.
            /// </summary>
            public const string Player = "Kyoshi";

            /// <summary>
            /// The Whater Whip Bend.
            /// </summary>
            public const string WhaterWhip = Water + "Whip";
        }

        /// <summary>
        /// Player constant attributes.
        /// </summary>
        public static class Player
        {
            /// <summary>
            /// Player Movement Speed.
            /// </summary>
            public const float Speed = 5.0f;

            /// <summary>
            /// Player Jump Force.
            /// </summary>
            public const float Force = 250.0f;

            /// <summary>
            /// Player Dash Impulse.
            /// </summary>
            public const float Impulse = 300.0f;
        }

        /// <summary>
        /// Constant names for <see cref="UnityEngine.Resources"/>.
        /// </summary>
        public static class Resources
        {
            /// <summary>
            /// The default Cursor.
            /// </summary>
            public const string Cursor = "Cursor";

            /// <summary>
            /// The Air themed Cursor.
            /// </summary>
            public const string CursorAir = Cursor + Air;

            /// <summary>
            /// The Earth themed Cursor.
            /// </summary>
            public const string CursorEarth = Cursor + Earth;

            /// <summary>
            /// The Fire themed Cursor.
            /// </summary>
            public const string CursorFire = Cursor + Fire;

            /// <summary>
            /// The Water themed Cursor.
            /// </summary>
            public const string CursorWater = Cursor + Water;
        }

        /// <summary>
        /// Tags constants names.
        /// </summary>
        public static class Tags
        {
            /// <summary>
            /// Determine the nature of Air.
            /// </summary>
            public const string Air = "Air";

            /// <summary>
            /// Determine the nature of Earth.
            /// </summary>
            public const string Earth = "Earth";

            /// <summary>
            /// Determine the nature of Fire.
            /// </summary>
            public const string Fire = "Fire";

            /// <summary>
            /// Determine the nature of Water.
            /// </summary>
            public const string Water = "Water";

            /// <summary>
            /// Mark as a part of Floor.
            /// </summary>
            public const string Floor = "Floor";
        }
    }
}