using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roca : MonoBehaviour
{
    //velocidad eje X
    private float velocidadX = -6f;
    //panel de game over
    public GameObject panelDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //creo un movimiento sin aceleraciones a la izquierda
        transform.Translate(Vector3.right * velocidadX * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //dependiendo con que colisione este objeto hago que se destruya a si mismo tambien o solo destruya el objeto con el que choca
        if (collision.gameObject.CompareTag("BalaPlayer") || collision.gameObject.CompareTag("BalaEnemyes"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemyes") || collision.gameObject.CompareTag("Enemyes2"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemyes Limit"))
        {
            Destroy(this.gameObject);
        }
    }
}