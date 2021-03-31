using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bend : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, 1.0f);

            Cursor.visible = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {        
        Cursor.visible = true;
        
        Destroy(gameObject);
    }
}
