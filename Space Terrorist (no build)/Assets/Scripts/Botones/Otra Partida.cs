using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OtraPartida : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReinicioEscena()
    {
        Time.timeScale = 1f;
        int reinicioEscena = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(reinicioEscena);
    }
}
