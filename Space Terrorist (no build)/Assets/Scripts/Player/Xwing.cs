using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xwing : MonoBehaviour
{
    //velocidad de la nave player
    private float velocidadNave = 10f;
    //vidas del player en este caso 3 vidas (vida 2, 1 y 0)
    public float vidaPlayer = 2f;
    //tiempo de inmunidad de player
    private float tiempoInmunidadPlayer = 2.5f;
    //el audio del impacto
    public AudioClip impacto;
    //el audio del derrota
    public AudioClip derrota;
    //panel de opciones
    public GameObject panelOpciones;
    // panel de jugador una vez destruido
    public GameObject panelDestroy;
    //panel de controles
    public GameObject panelControles;
    //panel info player
    public GameObject panelInfoPlayer;
    //estado de la inmunidad (true = si)
    private bool estadoInmunidad = false;
    //inicio de la inmunidad
    private float inicioInmunidad;
    //parpadeo de la nave para saber que es inmune
    private SpriteRenderer parpadeoNave;
    //colores de los powerups
    private Color colorPowerUpVida = Color.red;
    private Color colorPowerUpPuntos = Color.green;
    private Color colorPowerUpAtaque = Color.magenta;
    private Color colorOriginal = Color.white;
    //ca�ones secundarios
    public GameObject canonSecundario1;
    public GameObject canonSecundario2;
    // Start is called before the first frame update
    void Start()
    {
        //cojer el spriterenderer
        parpadeoNave = GetComponent<SpriteRenderer>();
        //apagar el panel game over
        panelDestroy.SetActive(false);
        //encender el panel info
        panelInfoPlayer.SetActive(true);
        //apagar los ca�ones secundarios    
        canonSecundario1.SetActive(false);
        canonSecundario2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Movimiento del circulo como si fuera un joystick de Derecha, Izquierda, Arriba, Abajo con WASD
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //hacer que el movimiento horizontal y vertical dependa de los getaxis
        Vector3 movimiento = new Vector3(horizontal, vertical, 0);
        transform.Translate(movimiento * velocidadNave * Time.deltaTime);
        //saber cuando se tiene que desactivar la inmunidad de la nave
        if (estadoInmunidad && Time.time - inicioInmunidad > tiempoInmunidadPlayer)
        {
            estadoInmunidad = false;
        }
        //abrir los menus y controles etc con esc
        if (Input.GetKeyDown(KeyCode.Escape) && !panelControles.activeSelf)
        {
            AbrirMenu();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!estadoInmunidad)
        {
            if (collision.gameObject.CompareTag("BalaEnemyes"))
            {
                //restar 1 vida a Player
                vidaPlayer--;
                // que avise a game manager
                GameManager.Instance.RestarVida();
                //activamos inmunidad
                estadoInmunidad = true;
                //establecemos que inicio de inmunidad es en el segundo que haya pasado desde que ha iniciado el juego
                inicioInmunidad = Time.time;
                StartCoroutine(InmunidadVisual());
                if (vidaPlayer < 0)
                {
                    // Destruir el Player
                    Destroy(gameObject);
                    panelDestroy.SetActive(true);
                    panelInfoPlayer.SetActive(false);
                }
            }
            //si la nave colisiona con un objeto que tiene el tag "Enemyes"
            if (collision.gameObject.CompareTag("Enemyes") || collision.gameObject.CompareTag("Enemyes2"))
            {
                //restar 1 vida a Player
                vidaPlayer--;
                //aviso a game manager
                GameManager.Instance.RestarVida();
                //lo devolvemos a la posicion inicial
                transform.position = new Vector3(-6f, 0, 0);
                //enciende inmunidad
                estadoInmunidad = true;
                inicioInmunidad = Time.time;
                StartCoroutine(InmunidadVisual());
                if (vidaPlayer < 0)
                {
                    // Destruir a Player
                    Destroy(gameObject);
                    //encender game over y apagar info
                    panelDestroy.SetActive(true);
                    panelInfoPlayer.SetActive(false);
                }
            }
            //si colisiona con "Enemyes" o "BalaEnemyes" que haga el sonido de impacto si le quedan mas de 1 bala para morir
            if (collision.gameObject.CompareTag("Enemyes") || collision.gameObject.CompareTag("Enemyes2") || collision.gameObject.CompareTag("BalaEnemyes") && vidaPlayer >= 0)
            {
                AudioSource.PlayClipAtPoint(impacto, transform.position);
            }
            //si colisiona con "Enemyes" o "BalaEnemyes" que haga el sonido de impacto si le queda 1 bala para morir
            else if (collision.gameObject.CompareTag("Enemyes") || collision.gameObject.CompareTag("Enemyes2") || collision.gameObject.CompareTag("BalaEnemyes") && vidaPlayer < 0)
            {
                AudioSource.PlayClipAtPoint(derrota, transform.position);
            }
            else if (collision.gameObject.CompareTag("Enemyes3"))
            {
                //matar al jugador
                Destroy(this.gameObject);
                //apagar info encender game over
                panelDestroy.SetActive(true);
                panelInfoPlayer.SetActive(false);
                //audio de derrota
                AudioSource.PlayClipAtPoint(derrota, transform.position);
            }
            if (vidaPlayer < 0)
            {
                PlayerDestruido();
            }
        }
    }
    IEnumerator InmunidadVisual()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        while(estadoInmunidad)
        {
            //parpadeo de la nave, para que se vea y luego no y luego si...
            parpadeoNave.enabled = !parpadeoNave.enabled;
            yield return new WaitForSeconds(0.1f);
        }
        GetComponent<BoxCollider2D>().enabled = true;
        parpadeoNave.enabled = true;
    }
    public void AbrirMenu()
    {
        //depende si el menu esta abierto o cerrado el juego sigue o se para
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
    public void PlayerDestruido()
    {
        //activar panel game over apagar info
        panelDestroy.SetActive(true);
        panelInfoPlayer.SetActive(false);
    }
    //pinta de rojo la nave
    public void SumarVidasXwing(int cantidad)
    {
        vidaPlayer += cantidad;
        if (parpadeoNave != null)
        {
            parpadeoNave.color = colorPowerUpVida;
        }
        Invoke("RestablecerColor", 1f);
    }
    //pinta de verde la nave
    public void MultiplicarPuntos()
    {
        if (parpadeoNave != null)
        {
            parpadeoNave.color = colorPowerUpPuntos;
        }
        Invoke("RestablecerColor", 7.5f);
    }
    //pinta de magenta la nave y da los ca�ones secundarios
    public void ActivarAtaque()
    {
        if (parpadeoNave != null)
        {
            parpadeoNave.color = colorPowerUpAtaque;
            canonSecundario1.SetActive(true);
            canonSecundario2.SetActive(true);
        }
        Invoke("RestablecerColor", 7.5f);
    }
    private void RestablecerColor()
    {
        if (parpadeoNave != null)
        {
            parpadeoNave.color = colorOriginal;
            canonSecundario1.SetActive(false);
            canonSecundario2.SetActive(false);
        }
    }
}