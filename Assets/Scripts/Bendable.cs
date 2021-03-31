using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;

public class Bendable : MonoBehaviour
{
    public bool ReadyToBend { get; private set; }

    private bool IsBending { get; set; }

    private void AllowBending()
    {
        BendCursor.Set(tag);

        ReadyToBend = true;
    }

    private void BlockBending()
    {
        ReadyToBend = false;

        BendCursor.SetDefault();

        Cursor.visible = true;
    }    

    private void FixedUpdate()
    {
        if(ReadyToBend)
        {
            if(Input.GetMouseButton(0))
            {
                Cursor.visible = false;

                switch(tag)
                {
                    case Tags.Air:
                        Helper.GetKyoshi().BendAir();
                    break;

                    case Tags.Earth:
                        Helper.GetKyoshi().BendEarth();
                    break;

                    case Tags.Fire:
                        Helper.GetKyoshi().BendFire();
                    break;

                    case Tags.Water:
                        Helper.GetKyoshi().BendWater();
                    break;
                }

                IsBending = true;

                Helper.GetKyoshi().disableMovement();

                return;
            }

            IsBending = false;
            
            BlockBending();        
            
            Helper.GetKyoshi().enableMovement();
        }
    }

    private void OnMouseExit()
    {
        if(IsBending)
        {
            switch(tag)
            {
                case Tags.Air:
                    UseAirBall();
                break;

                case Tags.Earth:
                    UseEarthBoulder();
                break;

                case Tags.Fire:
                    UseFireStream();
                break;

                case Tags.Water:
                    UseWaterWhip();
                break;
            }

            return;
        }

        BlockBending();
    }

    private void OnMouseOver()
    {
        if(!IsBending)
        {
            AllowBending();
        }
    }    

    private void Start()
    {
        ReadyToBend = false;
        IsBending = false;
    }

    private void UseBend(string path)
    {
        GameObject bend = Instantiate(
            Helper.LoadResource<GameObject>(path),
            Helper.FixedCurrentMouseWorldPoint(),
            Quaternion.identity
        );

        Physics2D.IgnoreCollision(bend.GetComponent<Collider2D>(), Helper.GetPlayer().GetComponent<Collider2D>());
    }

    private void UseAirBall() => UseBend($"{Path.Prefab}{GameObjects.AirBall}");

    private void UseEarthBoulder() => UseBend($"{Path.Prefab}{GameObjects.EarthBoulder}");

    private void UseFireStream() => UseBend($"{Path.Prefab}{GameObjects.FireStream}");

    private void UseWaterWhip() => UseBend($"{Path.Prefab}{GameObjects.WhaterWhip}");
}
