using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkGround : MonoBehaviour
{
    public static bool isGrounded;

    //verificamos si existe colision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }

    private void OnTriggertExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
