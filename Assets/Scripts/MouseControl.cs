using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    Vector2 mousePosition;

    public Rigidbody2D rb;

    public Camera cam;

    public bool isTurn;

    private void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 look = mousePosition - rb.position;

        if (look.x < 0)
        {
            rb.GetComponent<SpriteRenderer>().flipX = true;
            isTurn = true;
        }
        else if (look.x > 0)
        {
            rb.GetComponent<SpriteRenderer>().flipX = false;
            isTurn = false;
        }
    }
}
