using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigenDisparoDestructor : MonoBehaviour
{
    //explicado todo en OrigenDisparoTIE
    public GameObject baladestPrefab;
    public Transform origenDisparo;
    private float velocidadBala = 5f;
    private Camera camaraMain;
    private float cooldownBala = 4f;
    void Start()
    {
        //cooldown entre disparos, invoca disparo nada mas empezar y cada 2 segundos
        InvokeRepeating("Disparo", 5.5f, cooldownBala);
        camaraMain = Camera.main;
    }
    void Update()
    {

    }
    public void CooldownDisparo(float nuevoTiempo)
    {
        cooldownBala = nuevoTiempo;
    }
    void Disparo()
    {
        if (EnemigoEnCamara())
        {
            GameObject jugador = GameObject.FindGameObjectWithTag("Player");

            if (jugador != null)
            {
                //crea una bala a partir de la balaprefab  con cierta rotacion y en la posicion del spawn
                GameObject bala = Instantiate(baladestPrefab, origenDisparo.position, Quaternion.identity);
                //establecer una rotacion en la bala
                bala.transform.Rotate(0, 180, 0);
                //direccion del rigidbody2d de la bala para que mire al jugador
                Vector3 direccion = bala.transform.forward;
                //hacer que la bala se dirija al jugador mirandolo
                bala.GetComponent<Rigidbody2D>().velocity = direccion * velocidadBala;
            }
        }
    }
    bool EnemigoEnCamara()
    {
        Vector3 posicionEnPantalla = camaraMain.WorldToViewportPoint(transform.position);
        return posicionEnPantalla.x >= 0f && posicionEnPantalla.x <= 1f && posicionEnPantalla.y >= 0f && posicionEnPantalla.y <= 1f;
    }
}