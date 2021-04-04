using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MestreTramadorEMulherMotoca
{
    namespace Extras
    {
        public sealed class Commands : MonoBehaviour
        {
            public static void Read(string command)
            {
                Debug.Log(command);
            }

            private static class CommandList
            {
                // TODO: Define Commands.
            }
        }
    }
}
