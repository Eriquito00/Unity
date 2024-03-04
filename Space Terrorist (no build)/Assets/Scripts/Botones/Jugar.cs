using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadSceneJugar()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
