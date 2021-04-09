using UnityEngine;

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
                Debug.Log(command);
            }

            /// <summary>
            /// The current list of Commands.
            /// </summary>
            private static class CommandList
            {
            /**
             * Commands List:
             *
             * * Moto
             * * Trama
             * * Black
             * * Roku
             * * Azenha
             * * Careca
             * * Coca
             */                
            }
        }
    }
}
