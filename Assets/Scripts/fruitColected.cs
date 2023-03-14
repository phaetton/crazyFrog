using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitColected : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /***
         * colisi�n del jugador con la fruta
         * Desactivamos la manzana
         * Activamos la explosi�n
         * Hacemos la animaci�n
         * Eliminamos el objeto entero
        */

        if (collision.CompareTag("Player")){
           GetComponent<SpriteRenderer>().enabled= false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 0.5f); 
        }
    }
}
