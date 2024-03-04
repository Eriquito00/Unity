using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIE : MonoBehaviour
{
    //Velocidad de movimiento en el eje Y
    private float velocidadTIEejeY = 2f;
    //Longitud de movimiento
    private float longitudTIE = 1.5f;
    //Vidas
    private float vidaTIE = 0;
    //el audio del impacto
    public AudioClip impacto;
    //el audio del derrota
    public AudioClip derrota;
    //posicion en el eje Y
    private float posicionNaveTIEY;
    //velocidad en eje X
    private float velocidadX = -1f;
    //puntos para el jugador al ser derrotada
    public int puntosDestroyed = 25;
    // Start is called before the first frame update
    void Start()
    {
        posicionNaveTIEY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //un movimiento sinuosuidal que hace la nave en el eje Y 
        float ejeY = posicionNaveTIEY + Mathf.Sin(Time.time * velocidadTIEejeY) * longitudTIE;
        transform.position = new Vector3(transform.position.x, ejeY, transform.position.z);
        //un movimiento continuo a la izquierda
        transform.Translate(Vector3.right * velocidadX * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //ver si colisiona con el tag Player o BalaPlayer
        if (collision.gameObject.CompareTag("BalaPlayer") || collision.gameObject.CompareTag("Player"))
        {
            //restar 1 vida a TIE
            vidaTIE--;
            //matar al TIE
            derrotaTIE();
        }
        //sonidos de impacto o derrota dependiendo con que colisione
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("BalaPlayer") && vidaTIE >= 0)
        {
            AudioSource.PlayClipAtPoint(impacto, transform.position);
        }
        else if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("BalaPlayer") && vidaTIE < 0)
        {
            AudioSource.PlayClipAtPoint(derrota, transform.position);
        }
        else if (collision.gameObject.CompareTag("Enemyes3"))
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(derrota, transform.position);
        }
        //hacer que al chocar con el limite Enemyes Limit se destruya
        if (collision.gameObject.CompareTag("Enemyes Limit"))
        {
            posicionNaveTIEY = 0f;
            Destroy(gameObject);
        }
    }
    //Funcion para contar los puntos y enviarlos al gameManager
    public void derrotaTIE()
    {
        if (vidaTIE < 0)
        {
            // Destruir el TIE
            Destroy(gameObject);
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SumarPuntos(puntosDestroyed);
                GameManager.Instance.CambiarMaxPuntos();
            }
        }
    }
}
