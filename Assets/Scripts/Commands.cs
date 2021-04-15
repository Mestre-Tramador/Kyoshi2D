using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using static MestreTramadorEMulherMotoca.Constants.AudioClipNames;
using MestreTramadorEMulherMotoca.Util;
using static MestreTramadorEMulherMotoca.Util.Helper;

namespace MestreTramadorEMulherMotoca
{
    namespace Extras
    {
        /// <summary>
        /// The Commands used in the Console.
        /// </summary>
        public sealed class Commands : MonoBehaviour
        {
            /// <summary>
            /// Read and accept the given Command.
            /// </summary>
            /// <param name="command">The entry of the Terminal.</param>
            public static void Read(string command)
            {
                switch(command)
                {
                    case CommandList.AZENHA:
                        ReplaceThemeDisc(LoadResource<AudioClip>($"{Path.Music}{ThemeAzenha}"));
                    break;

                    case CommandList.BLACK:
                        ReplaceThemeDisc(LoadResource<AudioClip>($"{Path.Music}{ThemeBlack}"));
                    return;

                    case CommandList.ORIGINAL:
                        ReplaceThemeDisc(GetSceneOriginalTheme());
                    return;

                    case CommandList.XMEN:
                    ReplaceThemeDisc(LoadResource<AudioClip>($"{Path.Music}{ThemeMutant}"));
                    break;
                }

                void ReplaceThemeDisc(AudioClip replaceDisc) => GetJukebox().StopDiscOne().ReplaceDiscOne(replaceDisc).PutDiscOneInLoop().PlayDiscOne();
            }

            /// <summary>
            /// Get the original scene theme, aka the Jukebox disc 1.
            /// </summary>
            /// <returns>The referenced disc.</returns>
            private static AudioClip GetSceneOriginalTheme()
            {
                switch(SceneLoader.Current())
                {
                    case SceneNames.BookAir:   return LoadResource<AudioClip>($"{Path.Music}{ThemeAir}");
                    case SceneNames.BookEarth: return LoadResource<AudioClip>($"{Path.Music}{ThemeEarth}");
                    case SceneNames.BookFire:  return LoadResource<AudioClip>($"{Path.Music}{ThemeFire}");
                    case SceneNames.BookWater: return LoadResource<AudioClip>($"{Path.Music}{ThemeWater}");
                    case SceneNames.Menu:      return LoadResource<AudioClip>($"{Path.Music}{MenuAmbience}");
                }

                return null;
            }

            /// <summary>
            /// The current list of Commands.
            /// </summary>
            private static class CommandList
            {
                /// <summary>
                /// "Venho do Bairro da Azenha..."
                /// </summary>
                public const string AZENHA = "azenha";

                /// <summary>
                /// What would the world be without the Blacks' chaos?
                /// </summary>
                public const string BLACK = "black";

                /// <summary>
                /// End that motherfucker's life!
                /// </summary>
                public const string CARECA = "careca";

                /// <summary>
                /// Kyoshi is his aunt.
                /// </summary>
                public const string COCA = "coca";

                /// <summary>
                /// Yeah, she's allways right.
                /// </summary>
                public const string MOTO = "mulhermotoca";

                /// <summary>
                /// Return to the origin.
                /// </summary>
                public const string ORIGINAL = "original";

                /// <summary>
                /// The future is not good sometimes...
                /// </summary>
                public const string ROKU = "roku";

                /// <summary>
                /// Blame him for this all.
                /// </summary>
                public const string TRAMA = "mestretramador";

                /// <summary>
                /// Stan Lee must be proud...
                /// </summary>
                public const string XMEN = "mutant";
            }
        }
    }
}