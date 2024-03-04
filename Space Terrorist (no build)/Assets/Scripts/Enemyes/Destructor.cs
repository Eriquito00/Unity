using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    //Vidas de las naves destructor
    private float vidaDestructor = 1;
    //el audio del impacto
    public AudioClip impacto;
    //el audio del derrota
    public AudioClip derrota;
    //velocidad eje X
    private float velocidadX = -1f;
    public int puntosDestroyed = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //crear un vector con una velocidad a la izquierda constante
        transform.Translate(Vector3.right * velocidadX * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobar si la colisión es con un objeto que tenga la etiqueta "Player" o "BalaPlayer
        if (collision.gameObject.CompareTag("BalaPlayer") || collision.gameObject.CompareTag("Player"))
        {
            //restar 1 vida a TIE
            vidaDestructor--;
            //ejecutar derrotarDestructor
            derrotaDestructor();
        }
        //reproducir un audio o otro dependiendo de la condicion de la nave
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("BalaPlayer") && vidaDestructor >= 0)
        {
            AudioSource.PlayClipAtPoint(impacto, transform.position);
        }
        else if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("BalaPlayer") && vidaDestructor < 0)
        {
            AudioSource.PlayClipAtPoint(derrota, transform.position);
        }
        else if (collision.gameObject.CompareTag("Enemyes3"))
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(derrota, transform.position);
        }
        //destruir la nave al llegar al limite de los Enemigos
        if (collision.gameObject.CompareTag("Enemyes Limit"))
        {
            Destroy(this.gameObject);
        }
    }
    public void derrotaDestructor()
    {
        if (vidaDestructor < 0)
        {
            // Destruir el Destructor
            Destroy(this.gameObject);
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SumarPuntos(puntosDestroyed);
                GameManager.Instance.CambiarMaxPuntos();
            }
        }
    }
}
