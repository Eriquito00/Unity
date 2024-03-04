using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2 : MonoBehaviour
{
    //prefab nave
    public GameObject Dest;
    //spawns de la nave
    public Transform[] spawns;
    //tiempo de spawns
    private float tiempoSpawn;
    //spawn disponible si o no
    private bool spawnDispo = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnearNaves());
    }
    //cambiar el tiempo de spawn para aumentar la dificultad mas adelante
    public void CambiarTiempoSpawn(float nuevoTiempo)
    {
        tiempoSpawn = nuevoTiempo;
    }
    //permitir o no permitir que spawneen las naves
    public void SpawnDispo(bool permitir)
    {
        spawnDispo = permitir;
    }
    IEnumerator SpawnearNaves()
    {
        while (true)
        {
            if (spawnDispo)
            {
                //elige un spawn
                Transform spawnPoint = spawns[Random.Range(0, spawns.Length)];
                //coje la posicion del spawn
                Vector3 spawnPosition = spawnPoint.position;
                //crea el prefab en el punto del spawn con la rotacion por defecto
                Instantiate(Dest, spawnPosition, Quaternion.identity);
            }
            //tiempo en el que spawneara, depende del momento de la partida
            yield return new WaitForSeconds(tiempoSpawn);
        }
    }
}