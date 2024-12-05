using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pelota : MonoBehaviour
{
    public static Pelota instance;
    [SerializeField]
    GameObject menu;

    [SerializeField]
    GameObject[] bloques;

    [SerializeField]
    GameObject[] localizacionesBloques;

    [SerializeField]
    GameObject juego;

    [SerializeField]
    GameObject jugador;

    [SerializeField]
    GameObject pantallaVictoria;

    [SerializeField]
    GameObject pelota;

    private bool isBallMoving;
    float numeroDeVidas = 3;
    public Rigidbody rb;

    [SerializeField]
    GameObject gameOver;

    [SerializeField]
    TextMeshProUGUI textoVidas;

    [SerializeField]
    int puntuacionTotal;

    [SerializeField]
    TextMeshProUGUI puntuacionTexto;

    [SerializeField]
    TextMeshProUGUI puntuacionTextoGameOver;
    [SerializeField]
    TextMeshProUGUI puntuacionTextoVictoria;

    [SerializeField]
    TextMeshProUGUI highScoreText;

    [SerializeField]
    float highScore;

    [SerializeField]
    float puntosGanar;



    void Start()
    {
     rb = GetComponent<Rigidbody>();
     UpdateHighScore();
      
    }
    private void Awake()
    {
        if (Pelota.instance == null)
        {
            Pelota.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        if (juego.activeSelf)
        {
            textoVidas.text = numeroDeVidas.ToString("00");
            if (Input.GetKeyDown(KeyCode.Space) && !isBallMoving)
                {
                transform.parent = null;
                    gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(-40.0f,40.0f),450,0);
                    isBallMoving = true;               
                }
            if (numeroDeVidas <= 0)
            {
                juego.SetActive(false);
                puntuacionTextoGameOver.text = "-Puntuacion: " + puntuacionTotal.ToString("00000");
                gameOver.SetActive(true);
            }
           if (puntosGanar >= 35 )
            {
                juego.SetActive(false);
                pantallaVictoria.SetActive(true);
                puntuacionTextoVictoria.text = puntuacionTotal.ToString("00000");
            }
        }
    }
    public void SumarPuntuacion(int puntuacion)
    {
        if (juego.activeSelf)
        {
         puntuacionTotal = puntuacionTotal + puntuacion;
         puntuacionTexto.text = puntuacionTotal.ToString("00000");
         CheckHighScore();
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            numeroDeVidas = numeroDeVidas - 1;
            isBallMoving = false;
            rb.isKinematic = true;
            rb.isKinematic = false;
            pelota.transform.parent = jugador.transform;
            pelota.transform.position = jugador.transform.position;
        }
        if (col.gameObject.CompareTag("Block"))
        {
            puntosGanar = puntosGanar + 1;
        }
        if (col.gameObject.CompareTag("bolapuntos"))
        {
            puntuacionTotal = puntuacionTotal + 1000;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("bolavidas"))
        {
            numeroDeVidas = numeroDeVidas + 1;
            Destroy(col.gameObject);
        }
    }
   
    void CheckHighScore()
    {
        if(puntuacionTotal > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", puntuacionTotal);
        }
    }
    void UpdateHighScore()
    {
        highScoreText.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    public void Jugar()
    {
        juego.SetActive(true);
        menu.SetActive(false);
        
    }
}

