using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaXwing : MonoBehaviour
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
        // Comprobar si la colisión es con un objeto que tenga la etiqueta "Enemyes" o "WorldLimit" o "BalaEnemyes"
        if (collision.gameObject.CompareTag("WorldLimit") || collision.gameObject.CompareTag("Enemyes") || collision.gameObject.CompareTag("BalaEnemyes") || collision.gameObject.CompareTag("Enemyes2"))
        {
            // Destruir la bala
            Destroy(gameObject);
        }
        //que si colisiona con "BalaEnemyes" que haga el sonido impacto
        if (collision.gameObject.CompareTag("BalaEnemyes"))
        {
            AudioSource.PlayClipAtPoint(impacto, transform.position);
        }
        else if (collision.gameObject.CompareTag("Enemyes3"))
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(impacto, transform.position);
        }
    }
}
