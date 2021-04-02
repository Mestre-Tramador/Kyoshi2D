using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;

public class Bar : MonoBehaviour
{
    // TODO: Create specific class for menu.
    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneLoader.Load(SceneNames.PreBook, SceneData.BookEarth);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneLoader.Load(SceneNames.PreBook, SceneData.BookFire);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneLoader.Load(SceneNames.PreBook, SceneData.BookAir);
        }

        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneLoader.Load(SceneNames.PreBook, SceneData.BookWater);
        }
    }
}
