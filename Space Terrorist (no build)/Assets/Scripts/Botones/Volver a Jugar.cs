using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolveraJugar : MonoBehaviour
{
    //panel de opciones
    public GameObject panelOpciones;
    // Start is called before the first frame update
    void Start()
    {
        panelOpciones.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void VolverAlJuego()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            panelOpciones.SetActive(false);
        }
        else if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            panelOpciones.SetActive(true);
        }
    }
}
