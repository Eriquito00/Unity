using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Musica : MonoBehaviour
{
    public AudioClip musicaMenu;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //establecer la musica en el menu de inicio con cierto volumen
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = musicaMenu;
        audioSource.volume = 0.05f;
        ReproducirMusica();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            ReproducirMusica();
        }
    }
    void ReproducirMusica()
    {
        // Verificar si la música no se está reproduciendo
        if (!audioSource.isPlaying)
        {
            // Reproducir la música
            audioSource.Play();
        }
    }
}
