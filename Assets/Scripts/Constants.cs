using System.Collections.Generic;
using static MestreTramadorEMulherMotoca.Constants.Tags;

namespace MestreTramadorEMulherMotoca
{
    namespace Constants
    {
        /// <summary>
        /// The Constant names for the <see cref="UnityEngine.AudioClip"/> instances.
        /// </summary>
        public static class AudioClipNames
        {
            /// <summary>
            /// The chanting for a Book Subtitle.
            /// </summary>
            private const string BookChant = "BookChant";

            /// <summary>
            /// The chanting for the Air Book Subtitle.
            /// </summary>
            public const string BookChantAir = BookChant + Air;

            /// <summary>
            /// The chanting for the Earth Book Subtitle.
            /// </summary>
            public const string BookChantEarth = BookChant + Earth;

            /// <summary>
            /// The chanting for the Fire Book Subtitle.
            /// </summary>
            public const string BookChantFire = BookChant + Fire;

            /// <summary>
            /// The chanting for the Water Book Subtitle.
            /// </summary>
            public const string BookChantWater = BookChant + Water;

            /// <summary>
            /// The reading theme of a Book.
            /// </summary>
            public const string BookReading = "BookReading";

            /// <summary>
            /// The Kyoshi Dashing sound effect.
            /// </summary>
            public const string KyoshiDash = "KyoshiDash";

            /// <summary>
            /// The Kyoshi Jumping sound effect.
            /// </summary>
            public const string KyoshiJump = KyoshiMove;

            /// <summary>
            /// The Kyoshi Double Jumping sound effect.
            /// </summary>
            public const string KyoshiDoubleJump = "KyoshiJumpAir";

            /// <summary>
            /// The Kyoshi Moving sound effect.
            /// </summary>
            public const string KyoshiMove = "KyoshiStep";

            /// <summary>
            /// The Menu ambience music.
            /// </summary>
            public const string MenuAmbience = "MenuAmbience";

            /// <summary>
            /// The Menu entrance music.
            /// </summary>
            public const string MenuEntrance = "MenuEntrance";
        }

        /// <summary>
        /// The Contants names for <see cref="UnityEngine.GameObject"/> instances.
        /// </summary>
        public static class GameObjectNames
        {
            /// <summary>
            /// The Air Ball <see cref="Bend"/>.
            /// </summary>
            public const string AirBall = Air + "Ball";

            /// <summary>
            /// The <see cref="Book"/> Background.
            /// </summary>
            public const string Background = "Background";

            /// <summary>
            /// The Earth Boulder <see cref="Bend"/>.
            /// </summary>
            public const string EarthBoulder = Earth + "Boulder";

            /// <summary>
            /// The Fire Stream <see cref="Bend"/>.
            /// </summary>
            public const string FireStream = Fire + "Stream";

            /// <summary>
            /// The Jukebox itself.
            /// </summary>
            public const string Jukebox = "Jukebox";

            /// <summary>
            /// The <see cref="Book"/> Label.
            /// </summary>
            public const string Label = "Label";

            /// <summary>
            /// The Player, aka, <see cref="Kyoshi"/>.
            /// </summary>
            public const string Player = "Kyoshi";

            /// <summary>
            /// The <see cref="Book"/> Number.
            /// </summary>
            public const string Number = "Number";

            /// <summary>
            /// The <see cref="Book"/> Subtitle.
            /// </summary>
            public const string Subtitle = "Subtitle";

            /// <summary>
            /// The <see cref="Book"/> Symbol.
            /// </summary>
            public const string Symbol = "Symbol";

            /// <summary>
            /// The <see cref="Book"/> Title.
            /// </summary>
            public const string Title = "Title";

            /// <summary>
            /// The Terminal used as <see cref="MestreTramadorEMulherMotoca.Extras.Console"/>.
            /// </summary>
            public const string Terminal = "Terminal";

            /// <summary>
            /// The Whater Whip <see cref="Bend"/>.
            /// </summary>
            public const string WhaterWhip = Water + "Whip";
        }

        /// <summary>
        /// Constants Lang Keys to access JSON data.
        /// </summary>
        public static class Lang
        {
            /// <summary>
            /// Lang Keys to the <see cref="Book"/> scenes.
            /// </summary>
            public static class Books
            {
                /// <summary>
                /// The Label.
                /// </summary>
                public const string Label = "LABEL";

                /// <summary>
                /// The Title.
                /// </summary>
                public const string Title = "TITLE";

                /// <summary>
                /// The Subtitle.
                /// </summary>
                public const string Subtitle = "SUBTITLE";

                /// <summary>
                /// The Number.
                /// </summary>
                public const string Number = "NUMBER";

                #pragma warning disable CS0114
                /// <summary>
                /// The self key.
                /// </summary>
                /// <returns>The key for the <see cref="Books"/> entry.</returns>
                public static string ToString()
                {
                    return "BOOKS";
                }
                #pragma warning restore CS0114
            }
        }

        /// <summary>
        /// Player constant attributes.
        /// </summary>
        public static class Player
        {
            /// <summary>
            /// Player Jump Force.
            /// </summary>
            public const float Force = 250.0f;

            /// <summary>
            /// Player Dash Impulse.
            /// </summary>
            public const float Impulse = 300.0f;            

            /// <summary>
            /// Player Movement Speed.
            /// </summary>
            public const float Speed = 5.0f;            
        }

        /// <summary>
        /// Constant names for <see cref="UnityEngine.Resources"/>.
        /// </summary>
        public static class ResourceNames
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

            /// <summary>
            /// The English Language JSON file.
            /// </summary>
            public const string En = "En";

            /// <summary>
            /// The Four Nations Symbol.
            /// </summary>
            public const string Nations = "Nations";

            /// <summary>
            /// The Air Nomads Symbol.
            /// </summary>
            public const string NationsAir = Nations + Air;

            /// <summary>
            /// The Earth Kingdom Symbol.
            /// </summary>
            public const string NationsEarth = Nations + Earth;

            /// <summary>
            /// The Fire Nation Symbol.
            /// </summary>
            public const string NationsFire = Nations + Fire;

            /// <summary>
            /// The Water Tribe Symbol.
            /// </summary>
            public const string NationsWater = Nations + Water;

            /// <summary>
            /// The Brazilian Portuguese JSON file.
            /// </summary>
            public const string PtBr = "PtBr";
        }

        /// <summary>
        /// The Contants names for <see cref="UnityEngine.SceneManagement.Scene"/> instances.
        /// </summary>
        public static class SceneNames
        {
            /// <summary>
            /// The third level.
            /// </summary>
            public const string BookAir = "BookAir";

            /// <summary>
            /// The first level.
            /// </summary>
            public const string BookEarth = "BookEarth";

            /// <summary>
            /// The second level.
            /// </summary>
            public const string BookFire = "BookFire";

            /// <summary>
            /// The fourth level.
            /// </summary>
            public const string BookWater = "BookWater";

            /// <summary>
            /// The loading screen.
            /// </summary>
            public const string PreBook = "PreBook";
        }

        /// <summary>
        /// Specific data parameters for <see cref="UnityEngine.SceneManagement.Scene"/> instances.
        /// </summary>
        public static class SceneData
        {
            /// <summary>
            /// To load a <see cref="Book"/> with the Air theme.
            /// </summary>
            public static readonly KeyValuePair<string, string> BookAir = new KeyValuePair<string, string>("Book", "3");

            /// <summary>
            /// To load a <see cref="Book"/> with the Earth theme.
            /// </summary>
            public static readonly KeyValuePair<string, string> BookEarth = new KeyValuePair<string, string>("Book", "1");

            /// <summary>
            /// To load a <see cref="Book"/> with the Fire theme.
            /// </summary>
            public static readonly KeyValuePair<string, string> BookFire = new KeyValuePair<string, string>("Book", "2");

            /// <summary>
            /// To load a <see cref="Book"/> with the Water theme.
            /// </summary>
            public static readonly KeyValuePair<string, string> BookWater = new KeyValuePair<string, string>("Book", "4");
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