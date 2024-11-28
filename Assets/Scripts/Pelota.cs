using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pelota : MonoBehaviour
{
    public static Pelota instance;
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
    TextMeshProUGUI tiempoRestante;

    float tiempo = 300;
    [SerializeField]
    TextMeshProUGUI contador;

    [SerializeField]
    int puntuacionTotal;

    [SerializeField]
    TextMeshProUGUI puntuacionTexto;

    [SerializeField]
    TextMeshProUGUI puntuacionTextoGameOver;

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
            tiempo = tiempo - Time.deltaTime;
            contador.text = tiempo.ToString("000");
            textoVidas.text = numeroDeVidas.ToString("00");
            if (Input.GetKeyDown(KeyCode.Space) && !isBallMoving)
                { 
                    transform.parent = null;
                    gameObject.GetComponent<Rigidbody>().AddForce(0,450,0);
                    isBallMoving = true;               
                }
            Debug.Log(numeroDeVidas);
            if (numeroDeVidas <= 0)
            {
                juego.SetActive(false);
                tiempoRestante.text = "-Tiempo: " + (300 - tiempo).ToString("00:00");
                puntuacionTextoGameOver.text = "-Puntuacion: " + puntuacionTotal.ToString("00000");
                gameOver.SetActive(true);
            }
           if (puntosGanar >= 35)
            {
                juego.SetActive(false);
                pantallaVictoria.SetActive(true);
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
            if (col.gameObject.CompareTag("Block"))
            {
                puntosGanar = puntosGanar + 1;
            }
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
}
