using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //textos de vida, score y max score
    public Text vidasText;
    public Text puntosText;
    public Text puntosTextFinal;
    public Text maxpuntosText;
    public Text maxpuntosTextFinal;
    private static GameManager instance;
    private float vidasXwing = 2f;
    public float puntosplayer = 0f;
    private float maxpuntosPlayer = 0f;
    //puntos para power up
    private int puntosPowerUp = 350;
    void Start()
    {
        //si no tiene un max score empieza en 0
        maxpuntosPlayer = PlayerPrefs.GetFloat("MaxPuntos", 0f);
        instance = this;
        ActualizarVidasTexto();
        ActualizarPuntosTexto();
        ActualizarMaxPuntosTexto();
    }
    void Update()
    {
        //que vaya dando power up conforme avanza con los puntos
        if (puntosplayer >= puntosPowerUp)
        {
            Xwing scriptXwing = FindObjectOfType<Xwing>();
            //numero random del 0 al 2
            int numeroAleatorio = UnityEngine.Random.Range(0, 3);
            if (numeroAleatorio == 0)
            {
                scriptXwing.SumarVidasXwing(1);
                SumarVida();
                puntosPowerUp = 350 + puntosPowerUp;
            }
            else if (numeroAleatorio == 1)
            {
                scriptXwing.MultiplicarPuntos();
                StartCoroutine(MultiplicarPuntos());
                puntosPowerUp = 350 + puntosPowerUp;
            }
            else if (numeroAleatorio == 2)
            {
                scriptXwing.ActivarAtaque();
                puntosPowerUp = 350 + puntosPowerUp;
            }
        }
    }
    public static GameManager Instance
    {
        get { return instance; }
    }
    public float ValorPuntos()
    {
        return puntosplayer;
    }
    //power ups, suma la vida o resta en el texto de la info
    public void RestarVida()
    {
        vidasXwing--;
        ActualizarVidasTexto();
    }
    public void SumarVida()
    {
        vidasXwing++;
        ActualizarVidasTexto();
    }
    //texto y calculo de los puntos y max score
    public void SumarPuntos(int cantidad)
    {
        puntosplayer = cantidad + puntosplayer;
        ActualizarPuntosTexto();
        CambiarMaxPuntos();
    }
    public void CambiarMaxPuntos()
    {
        if (puntosplayer > maxpuntosPlayer)
        {
            maxpuntosPlayer = puntosplayer;
            ActualizarMaxPuntosTexto();
            PlayerPrefs.SetFloat("MaxPuntos", maxpuntosPlayer);
            PlayerPrefs.Save();
        }
    }
    //multiplicar los puntos power up
    private IEnumerator MultiplicarPuntos()
    {
        float puntosAntes = puntosplayer;
        yield return new WaitForSeconds(7.5f);
        float puntosDurante10Segundos = puntosplayer - puntosAntes;
        puntosDurante10Segundos *= 2;
        puntosplayer += puntosDurante10Segundos;
        ActualizarPuntosTexto();
    }
    //actualizar los textos de la info player y game over
    private void ActualizarVidasTexto()
    {
        if (vidasText != null)
        {
            vidasText.text = vidasXwing.ToString();
        }
    }
    private void ActualizarPuntosTexto()
    {
        if(puntosText != null)
        {
            puntosText.text = puntosplayer.ToString();
            puntosTextFinal.text = puntosplayer.ToString();
        }
    }
    private void ActualizarMaxPuntosTexto()
    {
        if (puntosText != null)
        {
            maxpuntosText.text = maxpuntosPlayer.ToString();
            maxpuntosTextFinal.text = maxpuntosPlayer.ToString();
        }
    }
}