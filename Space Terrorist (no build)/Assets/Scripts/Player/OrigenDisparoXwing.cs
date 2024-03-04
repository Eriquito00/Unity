using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigenDisparoXwing : MonoBehaviour
{
    //prefab bala
    public GameObject balaXwingPrefab;
    //origen disparo posicion
    public Transform origenDisparo;
    //velocidad bala
    private float velocidadBala = 20f;
    //cooldown por disparo
    private float cooldownBala = 1f;
    //ultima bala disparada
    private float ultimaBala;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        //que compruebe cuando le queda de cooldown hasta el proximo disparo
        if (Time.time - ultimaBala > cooldownBala)
        {
            //si presiona E que dispare
            if (Input.GetKey(KeyCode.E))
            {
                Disparo();
                //saber cuando se ha disparado
                ultimaBala = Time.time;
            }
        }
    }

    void Disparo()
    {
        //invocar el prefab de la bala del xwing
        GameObject bala = Instantiate(balaXwingPrefab, origenDisparo.position, origenDisparo.rotation);
        Rigidbody2D balaRB = bala.GetComponent<Rigidbody2D>();
        //hacer que la bala vaya a la derecha
        balaRB.velocity = bala.transform.right * velocidadBala;
    }
}