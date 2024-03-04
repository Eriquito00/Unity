using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaTIE : MonoBehaviour
{
    //el audio del impacto
    public AudioClip impacto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobar si la colisión es con un objeto que tenga la etiqueta "Player" o "WorldLimit o "BalaPlayer"
        if (collision.gameObject.CompareTag("WorldLimit") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("BalaPlayer"))
        {
            // Destruir la bala
            Destroy(gameObject);
        }
        //dependiendo con que colisione la bala que reproduzca un sonido o otro
        if (collision.gameObject.CompareTag("BalaPlayer"))
        {
            AudioSource.PlayClipAtPoint(impacto, transform.position);
        }
        else if (collision.gameObject.CompareTag("Enemyes3"))
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(impacto, transform.position);
        }
        //hacer que si colisiona con la barrera de enmigos se destruya
        if (collision.gameObject.CompareTag("Enemyes Limit"))
        {
            Destroy(gameObject);
        }
    }
}
