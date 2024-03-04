using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn3 : MonoBehaviour
{
    //Prefab roca
    public GameObject rocaPrefab;
    //seleccion de los spawns de la roca
    public Transform[] spawns;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerarRocasProceduralmente());
    }

    System.Collections.IEnumerator GenerarRocasProceduralmente()
    {
        while (true)
        {
            //elegimos uno de los spawns
            Transform spawn = spawns[Random.Range(0, spawns.Length)];
            //cojemos en vector3 la posicion del spawn
            Vector3 spawnPosicion = spawn.position;
            //posicionamos el prefab en la posicion del spawn con la rotacion por defecto
            GameObject nuevaRoca = Instantiate(rocaPrefab, spawnPosicion, Quaternion.identity);
            nuevaRoca.transform.parent = spawn;
            //rango aleatorio entre 5 y 10
            float tiempoEspera = Random.Range(5f, 10f);
            //establecer que el tiempo entre ejecuciones sea entre el numero aleatorio entre 5 y 10
            yield return new WaitForSeconds(tiempoEspera);
        }
    }
}