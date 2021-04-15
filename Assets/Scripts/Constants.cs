using System.Collections.Generic;
using static MestreTramadorEMulherMotoca.Constants.Tags;

namespace MestreTramadorEMulherMotoca
{
    namespace Constants
    {
        /// <summary>
        /// The indexes of discs to the <see cref="Jukebox"/>.
        /// </summary>
        public static class DiscIndex
        {
            /// <summary>
            /// Disc "Move".
            /// </summary>
            public const int Move = 1;

            /// <summary>
            /// Disc "Jump".
            /// </summary>
            public const int Jump = 2;

            /// <summary>
            /// Disc "DoubleJump".
            /// </summary>
            public const int DoubleJump = 3;

            /// <summary>
            /// Disc "Dash".
            /// </summary>
            public const int Dash = 4;

            /// <summary>
            /// Disc "AirBend".
            /// </summary>
            public const int AirBend = 5;

            /// <summary>
            /// Disc "EarthBend".
            /// </summary>
            public const int EarthBend = 6;

            /// <summary>
            /// Disc "FireBend".
            /// </summary>
            public const int FireBend = 7;

            /// <summary>
            /// Disc "WaterBend".
            /// </summary>
            public const int WaterBend = 8;

            /// <summary>
            /// Disc "Pull".
            /// </summary>
            public const int Bend = 9;

            /// <summary>
            /// Disc "Dissipate".
            /// </summary>
            public const int Dissipate = 10;

            /// <summary>
            /// Disc "MoveBend".
            /// </summary>
            public const int MoveBend = 11;

            /// <summary>
            /// Disc "PlaceBend".
            /// </summary>
            public const int PlaceBend = 12;

            /// <summary>
            /// Disc "Pull".
            /// </summary>
            public const int Pull = 13;

            /// <summary>
            /// Disc "Impact".
            /// </summary>
            public const int Impact = 14;

            /// <summary>
            /// Disc "Obstacle".
            /// </summary>
            public const int Obstacle = 15;
        }

        /// <summary>
        /// The Constant names for the <see cref="UnityEngine.AudioClip"/> instances.
        /// </summary>
        public static class AudioClipNames
        {
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
            /// The impact of Earth sound effect.
            /// </summary>
            public const string EarthImpact = Earth + Impact;

            /// <summary>
            /// The bending of Earth sound effect.
            /// </summary>
            public const string EarthBend = Earth + Bend;

            /// <summary>
            /// The moving of Earth sound effect.
            /// </summary>
            public const string EarthMove = Earth + "Move";

            /// <summary>
            /// The pulling of Earth sound effect.
            /// </summary>
            public const string EarthPull = Earth + Pull;

            /// <summary>
            /// The continuous bending of Fire sound effect.
            /// </summary>
            public const string FireBend = Fire + Bend;

            /// <summary>
            /// The bending of Fire sound effect.
            /// </summary>
            public const string FireBendStart = FireBend + Start;

            /// <summary>
            /// The dissipation of the bending of Fire sound effect.
            /// </summary>
            public const string FireEnd = Fire + End;

            /// <summary>
            /// The impact of Fire sound effect.
            /// </summary>
            public const string FireImpact = Fire + Impact;

            /// <summary>
            /// The pulling of Fire sound effect.
            /// </summary>
            public const string FirePull = Fire + Pull;

            /// <summary>
            /// The Kyoshi Dashing sound effect.
            /// </summary>
            public const string KyoshiDash = Kyoshi + "Dash";

            /// <summary>
            /// The Kyoshi Jumping sound effect.
            /// </summary>
            public const string KyoshiJump = KyoshiMove;

            /// <summary>
            /// The Kyoshi Double Jumping sound effect.
            /// </summary>
            public const string KyoshiDoubleJump = Kyoshi + "JumpAir";

            /// <summary>
            /// The Kyoshi Moving sound effect.
            /// </summary>
            public const string KyoshiMove = Kyoshi + "Step";

            /// <summary>
            /// The Menu ambience music.
            /// </summary>
            public const string MenuAmbience = Menu + "Ambience";

            /// <summary>
            /// The Menu entrance music.
            /// </summary>
            public const string MenuEntrance = Menu + "Entrance";

            /// <summary>
            /// The lighting up of a Torch Obstacle.
            /// </summary>
            public const string ObstacleTorchLightUp = "ObstacleTorchLightUp";

            /// <summary>
            /// The Easter Egg theme "Grêmio da Geral".
            /// </summary>
            public const string ThemeAzenha = Theme + "Azenha";

            /// <summary>
            /// The Easter Egg theme "Back In Black", by AC/DC.
            /// </summary>
            public const string ThemeBlack = Theme + "Black";

            /// <summary>
            /// The Easter Egg theme from the 90's X-Men Cartoon.
            /// </summary>
            public const string ThemeMutant = Theme + "Mutant";

            /// <summary>
            /// The third level theme.
            /// </summary>
            public const string ThemeAir = Theme + Air;

            /// <summary>
            /// The first level theme.
            /// </summary>
            public const string ThemeEarth = Theme + Earth;

            /// <summary>
            /// The second level theme.
            /// </summary>
            public const string ThemeFire = Theme + Fire;

            /// <summary>
            /// The fourth level theme.
            /// </summary>
            public const string ThemeWater = Theme + Water;

            /// <summary>
            /// The Bending prefix.
            /// </summary>
            private const string Bend = "Bend";

            /// <summary>
            /// The chanting for a Book Subtitle.
            /// </summary>
            private const string BookChant = "BookChant";

            /// <summary>
            /// The endind of a Bend sufix.
            /// </summary>
            private const string End = "End";

            /// <summary>
            /// The impact of a Bend sufix.
            /// </summary>
            private const string Impact = "Impact";

            /// <summary>
            /// Avatar Kyoshi prefixation.
            /// </summary>
            private const string Kyoshi = "Kyoshi";

            /// <summary>
            /// Menu prefixation for themes.
            /// </summary>
            private const string Menu = "Menu";

            /// <summary>
            /// The pulling of a Bend sufix.
            /// </summary>
            private const string Pull = "Pull";

            /// <summary>
            /// The start of a Bend sufix.
            /// </summary>
            private const string Start = "Start";

            /// <summary>
            /// Theme prefixation for general musics.
            /// </summary>
            private const string Theme = "Theme";
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
            /// Acts as the <see cref="BookEnd"/> of the second level.
            /// </summary>
            public const string Altar = "Altar";

            /// <summary>
            /// The <see cref="Book"/> Background.
            /// </summary>
            public const string Background = "Background";

            /// <summary>
            /// An <see cref="Obstacle"/> Barrier.
            /// </summary>
            public const string Barrier = "Barrier";

            /// <summary>
            /// An <see cref="Obstacle"/> Boulder.
            /// </summary>
            public const string Boulder = "Boulder";

            /// <summary>
            /// Acts as the <see cref="BookEnd"/> of the first level.
            /// </summary>
            public const string Cliff = "Cliff";

            /// <summary>
            /// The Earth Boulder <see cref="Bend"/>.
            /// </summary>
            public const string EarthBoulder = Earth + "Boulder";

            /// <summary>
            /// The Curtains themselves.
            /// </summary>
            public const string Curtains = "Curtains";

            /// <summary>
            /// The Fire Stream <see cref="Bend"/>.
            /// </summary>
            public const string FireStream = Fire + "Stream";

            /// <summary>
            /// The Fillable of the <see cref="Hole"/> Obstacle.
            /// </summary>
            public const string Fillable = "Fillable";

            /// <summary>
            /// The Fuel of the Torch Obstacle.
            /// </summary>
            public const string Fuel = "Fuel";

            /// <summary>
            /// An <see cref="Obstacle"/> Hole.
            /// </summary>
            public const string Hole = "Hole";

            /// <summary>
            /// The Jukebox itself.
            /// </summary>
            public const string Jukebox = "Jukebox";

            /// <summary>
            /// The <see cref="Book"/> Label.
            /// </summary>
            public const string Label = "Label";

            /// <summary>
            /// The <see cref="Book"/> Number.
            /// </summary>
            public const string Number = "Number";

            /// <summary>
            /// The Player, aka, <see cref="Kyoshi"/>.
            /// </summary>
            public const string Player = "Kyoshi";

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
            public const float Force = 300.0f;

            /// <summary>
            /// Player Dash Impulse.
            /// </summary>
            public const float Impulse = 350.0f;

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
            /// The summary menu.
            /// </summary>
            public const string Menu = "Menu";

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
            /// Determine an Abyss.
            /// </summary>
            public const string Abyss = "Abyss";

            /// <summary>
            /// Determine the nature of Air.
            /// </summary>
            public const string Air = "Air";

            /// <summary>
            /// An invisible barrier.
            /// </summary>
            public const string Barrier = "Barrier";

            /// <summary>
            /// Determine the nature of Earth.
            /// </summary>
            public const string Earth = "Earth";

            /// <summary>
            /// Determine the nature of Fire.
            /// </summary>
            public const string Fire = "Fire";

            /// <summary>
            /// Mark as a part of Floor.
            /// </summary>
            public const string Floor = "Floor";

            /// <summary>
            /// Mark a return point on the Floor.
            /// </summary>
            public const string Return = "Return";

            /// <summary>
            /// Determine the nature of Water.
            /// </summary>
            public const string Water = "Water";
        }
    }
}