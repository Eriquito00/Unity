using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fondo : MonoBehaviour
{
    //velocidad del fondo
    private float velocidad = 5f;
    private float anchoFondo;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        anchoFondo = mainCamera.orthographicSize * 2 * mainCamera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        //que transforme la velocidad del fondo por detras de todo
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        //que si el fondo no sale en la camara que lo borre
        if (transform.position.x < mainCamera.transform.position.x - anchoFondo)
        {
            RepositionBackground();
        }
    }
    void RepositionBackground()
    {
        //poner otra vez la foto de fondo justo antes de que se vea en la camara
        transform.position = new Vector3(mainCamera.transform.position.x + anchoFondo, transform.position.y, transform.position.z);
    }
}
