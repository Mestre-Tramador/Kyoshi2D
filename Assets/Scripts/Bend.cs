using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MestreTramadorEMulherMotoca.Constants;
using MestreTramadorEMulherMotoca.Util;

public class Bend : MonoBehaviour
{
    public void Dissipate()
    {
        Cursor.visible = true;
        
        Destroy(gameObject);
    }

    private void Follow()
    {
        transform.position = Vector2.Lerp(
            transform.position,
            Helper.FixedCurrentMouseWorldPoint(),
            1.0f
        );
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {        
        Dissipate();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Follow();

            return;
        }

        if((CompareTag(Tags.Air) || CompareTag(Tags.Fire)) || !GetComponent<Renderer>().isVisible)
        {
            Dissipate();
        }
    }    
}
