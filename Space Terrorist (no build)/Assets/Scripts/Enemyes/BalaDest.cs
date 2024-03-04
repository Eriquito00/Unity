using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaDest : MonoBehaviour
{
    //velocidad de la bala
    private float velocidadBala = 6f;
    //gameobject del jugador
    private GameObject player;
    //el audio del impacto
    public AudioClip impacto;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestruirBala", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //saber a quien tiene que seguir
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 direccion = (player.transform.position - transform.position).normalized;
            // calcula hacia donde la bala rotara en direccion al jugador
            float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
            // rota la bala a donde esta el jugador
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo));
            GetComponent<Rigidbody2D>().velocity = direccion * velocidadBala;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobar si la colisión es con un objeto que tenga la etiqueta "Player" o "WorldLimit o "BalaPlayer"
        if (collision.gameObject.CompareTag("WorldLimit") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("BalaPlayer"))
        {
            // Destruir la bala
            Destroy(gameObject);
        }
        //dependiendo la colision que haga un sonido o otro
        if (collision.gameObject.CompareTag("BalaPlayer"))
        {
            AudioSource.PlayClipAtPoint(impacto, transform.position);
        }
        else if (collision.gameObject.CompareTag("Enemyes3"))
        {
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(impacto, transform.position);
        }
        //destruir el objeto si choca con el limite de enemigos
        if (collision.gameObject.CompareTag("Enemyes Limit"))
        {
            Destroy(gameObject);
        }
    }
    void DestruirBala()
    {
        Destroy(gameObject);
    }
}
