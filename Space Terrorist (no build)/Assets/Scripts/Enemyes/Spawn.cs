using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //explicado el mismo funcionamiento en spawn2
    public GameObject TIE;
    public Transform[] spawns;
    private float tiempoSpawn;
    private bool spawnDispo = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnearNaves());
    }
    public void CambiarTiempoSpawn(float nuevoTiempo)
    {
        tiempoSpawn = nuevoTiempo;
    }
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
                Transform spawnPoint = spawns[Random.Range(0, spawns.Length)];
                Vector3 spawnPosition = spawnPoint.position;
                Instantiate(TIE, spawnPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(tiempoSpawn);
        }
    }
}