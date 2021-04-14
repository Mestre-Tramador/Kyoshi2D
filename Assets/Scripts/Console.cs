using UnityEngine;
using UnityEngine.UI;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;

namespace MestreTramadorEMulherMotoca
{
    namespace Extras
    {
        /// <summary>
        /// Manages the use of Console.
        /// </summary>
        public sealed class Console : MonoBehaviour
        {
            /// <summary>
            /// Determines if the Terminal, aka the Console, is enabled.
            /// </summary>
            /// <value><see cref="true"/> if some instance was loaded.</value>
            public bool TerminalIsEnabled { get; private set; }

            /// <summary>
            /// The current instance of the Terminal <see cref="GameObject"/>.
            /// </summary>
            /// <value>
            /// It contains a <see cref="RectTransform"/>, an <see cref="Image"/> and a
            /// <see cref="Text"/>, as the last being a Child GameObject. Both contains
            /// a <see cref="CanvasRenderer"/> too.
            /// </value>
            private GameObject Instance { get; set; }

            /// <summary>
            /// Get the typed command on the Terminal.
            /// </summary>
            /// <returns>The string to be parsed.</returns>
            public string GetCommand() => Instance.GetComponent<InputField>().text.Trim().ToLower();

            /// <summary>
            /// Put the focus on the Terminal.
            /// </summary>
            private void ActivateTerminal()
            {
                if(TerminalIsEnabled)
                {
                    Instance.GetComponent<InputField>().ActivateInputField();
                }
            }

            /// <summary>
            /// If not instantiated, place the Terminal on screen and activate it.
            /// </summary>
            private void PlaceTerminal()
            {
                if(TerminalIsEnabled)
                {
                    return;
                }
                
                TerminalIsEnabled = true;

                Instance = Instantiate(Helper.LoadResource<GameObject>($"{Path.Prefab}{GameObjectNames.Terminal}"), transform);

                ActivateTerminal();
            }

            /// <summary>
            /// Simply remove the Terminal.
            /// </summary>
            private void RemoveTerminal()   
            {
                Destroy(Instance);

                Instance = null;

                TerminalIsEnabled = false;
            } 

            /// <summary>
            /// The Updater search of the instance of the Terminal,
            /// then keep the focus on it until remotion. <br/>
            /// 
            /// Else, it listens to the <see cref="KeyCode"/> activators
            /// to place a Terminal, or remove it.
            /// </summary>
            private void Update()
            {
                if(TerminalIsEnabled && Helper.GetAnyMouseClick())
                {
                    ActivateTerminal();

                    return;
                }

                if(Input.GetKey(KeyCode.Quote) && !TerminalIsEnabled)
                {
                    Helper.PauseGame();

                    BendCursor.SetDefault();
                    BendCursor.Hide();

                    PlaceTerminal();
                }

                if(Input.GetKey(KeyCode.Return) && TerminalIsEnabled)
                {
                    Helper.ResumeGame();
                    BendCursor.Unhide();

                    Commands.Read(GetCommand());

                    RemoveTerminal();
                }        
            }                       
        }
    }
}