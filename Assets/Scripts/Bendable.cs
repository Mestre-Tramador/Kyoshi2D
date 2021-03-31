using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;

public class Bendable : MonoBehaviour
{
    public bool ReadyToBend { get; private set; }

    private bool IsBending { get; set; }

    private void Start()
    {
        ReadyToBend = false;
        IsBending = false;
    }

    private void FixedUpdate()
    {
        if(ReadyToBend)
        {
            if(Input.GetMouseButton(0))
            {
                Kyoshi avatar = Helper.GetPlayer().GetComponent<Kyoshi>();

                switch(tag)
                {
                    case Keys.Air:
                        avatar.BendAir();
                    break;

                    case Keys.Earth:
                        avatar.BendEarth();
                    break;

                    case Keys.Fire:
                        avatar.BendFire();
                    break;

                    case Keys.Water:
                        avatar.BendWater();
                    break;
                }

                IsBending = true;
                
                return;
            }

            IsBending = false;
        }

        OnMouseExit();
    }

    private void OnMouseOver()
    {
        if(!IsBending)
        {
            BendCursor.Set(tag);

            ReadyToBend = true;
        }
    }

    private void OnMouseExit()
    {
        if(IsBending)
        {
            switch(tag)
            {
                case Keys.Air:
                    
                break;

                case Keys.Earth:
                    
                break;

                case Keys.Fire:
                    
                break;

                case Keys.Water:
                    GameObject bend = Instantiate<GameObject>(
                        UnityEngine.Resources.Load<GameObject>("Prefab/WaterBall"),
                        Camera.main.ScreenToWorldPoint(new Vector3(
                            Input.mousePosition.x,
                            Input.mousePosition.y,
                            1
                        )),
                        new Quaternion()
                    );

                    Debug.Log(bend.name);
                break;
            }
            
            return;
        }

        BendCursor.SetDefault();

        ReadyToBend = false;
    }
}
