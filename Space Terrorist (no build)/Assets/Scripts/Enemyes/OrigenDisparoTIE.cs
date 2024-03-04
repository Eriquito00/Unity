using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigenDisparoTIE : MonoBehaviour
{
    //prefab de la bala
    public GameObject balaTIEPrefab;
    //posicion del origen disparo
    public Transform origenDisparo;
    //velocidad de la bala
    private float velocidadBala = 10f;
    //camara del juego
    private Camera camaraMain;
    //cooldown de la bala
    private float cooldownBala = 2f;
    // Start is called before the first frame update
    void Start()
    {
        //cooldown entre disparos, invoca disparo al segundo de empezar y cada 2 segundos
        InvokeRepeating("Disparo", 1f, cooldownBala);
        //asigno el valor de la camara a una variable
        camaraMain = Camera.main;
    }
    void Update()
    {

    }
    //modificacion del tiempo de disparo de un enemigo en otro script Dificultad
    public void CooldownDisparo(float nuevoTiempo)
    {
        cooldownBala = nuevoTiempo;
    }
    //disparar solo si la nave encuentra al jugador y esta en la camara la nave enemiga
    void Disparo()
    {
        if (EnemigoEnCamara())
        {
            //detectar el player
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");
            if (jugador != null)
            {
                //crea una bala a partir de la balaprefab  con cierta rotacion y en la posicion del spawn
                GameObject bala = Instantiate(balaTIEPrefab, origenDisparo.position, origenDisparo.rotation);
                Rigidbody2D balaRB = bala.GetComponent<Rigidbody2D>();
                balaRB.velocity = bala.transform.right * velocidadBala;
            }
        }
    }
    bool EnemigoEnCamara()
    {
        //establecer un limite que sea lo mismo que ocupa la camara
        Vector3 posicionEnPantalla = camaraMain.WorldToViewportPoint(transform.position);
        //establecer 4 puntos para que la nave solo pueda disparar dentro de esos puntos, los quales seran puntos en los limites de la camara
        return posicionEnPantalla.x >= 0f && posicionEnPantalla.x <= 1f && posicionEnPantalla.y >= 0f && posicionEnPantalla.y <= 1f;
    }
}
