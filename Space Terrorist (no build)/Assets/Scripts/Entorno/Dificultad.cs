using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dificultad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //cojer los valores de cooldown, tiempo de disparo etc
        float puntos = GameManager.Instance.ValorPuntos();
        Spawn spawn1 = FindObjectOfType<Spawn>();
        OrigenDisparoTIE balasTie = FindAnyObjectByType<OrigenDisparoTIE>();
        Spawn2 spawn2 = FindObjectOfType<Spawn2>();
        OrigenDisparoDestructor balasDest = FindAnyObjectByType<OrigenDisparoDestructor>();
        //dependiendo de los puntos hacer mas facil o dificil el juego
        if (puntos <= 300)
        {
            spawn1.SpawnDispo(true);
            spawn1.CambiarTiempoSpawn(2.25f);
            spawn2.SpawnDispo(false);
        }
        else if (puntos > 300 && puntos <= 700)
        {
            spawn1.SpawnDispo(true);
            spawn1.CambiarTiempoSpawn(4f);
            spawn2.SpawnDispo(true);
            spawn2.CambiarTiempoSpawn(15f);
        }
        else if (puntos > 700 && puntos <= 1500)
        {
            spawn1.SpawnDispo(true);
            spawn1.CambiarTiempoSpawn(3.5f);
            spawn2.SpawnDispo(true);
            spawn2.CambiarTiempoSpawn(12.5f);
        }
        else if (puntos > 1500 && puntos <= 2500)
        {
            spawn1.SpawnDispo(true);
            spawn1.CambiarTiempoSpawn(3f);
            spawn2.SpawnDispo(true);
            spawn2.CambiarTiempoSpawn(10f);
        }
        else if (puntos > 2500 && puntos <= 3500)
        {
            spawn1.SpawnDispo(true);
            spawn1.CambiarTiempoSpawn(3f);
            spawn2.SpawnDispo(true);
            spawn2.CambiarTiempoSpawn(10f);
            balasDest.CooldownDisparo(3.5f);
        }
        else if (puntos > 3500 && puntos <= 4500)
        {
            spawn1.SpawnDispo(true);
            spawn1.CambiarTiempoSpawn(2.75f);
            balasTie.CooldownDisparo(1.75f);
            spawn2.SpawnDispo(true);
            spawn2.CambiarTiempoSpawn(8f);
            balasDest.CooldownDisparo(3.5f);
        }
        else if (puntos > 4500 && puntos <= 5500)
        {
            spawn1.SpawnDispo(true);
            spawn1.CambiarTiempoSpawn(2.5f);
            balasTie.CooldownDisparo(1.5f);
            spawn2.SpawnDispo(true);
            spawn2.CambiarTiempoSpawn(7f);
            balasDest.CooldownDisparo(3.25f);
        }
        else if (puntos > 5500 && puntos <= 6500)
        {
            spawn1.SpawnDispo(true);
            spawn1.CambiarTiempoSpawn(2.25f);
            balasTie.CooldownDisparo(1.25f);
            spawn2.SpawnDispo(true);
            spawn2.CambiarTiempoSpawn(6f);
            balasDest.CooldownDisparo(3f);
        }
        else if (puntos > 6500)
        {
            spawn1.SpawnDispo(true);
            spawn1.CambiarTiempoSpawn(2f);
            balasTie.CooldownDisparo(1f);
            spawn2.SpawnDispo(true);
            spawn2.CambiarTiempoSpawn(5f);
            balasDest.CooldownDisparo(2.5f);
        }
    }
}
