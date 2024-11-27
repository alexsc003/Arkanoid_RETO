using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pelota : MonoBehaviour
{
    [SerializeField]
    GameObject juego;
    [SerializeField]
    GameObject jugador;
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


    void Start()
    {
     rb = GetComponent<Rigidbody>();
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
                    gameObject.GetComponent<Rigidbody>().AddForce(0,700,0);
                    isBallMoving = true;               
                }
            Debug.Log(numeroDeVidas);
            if (numeroDeVidas <= 0)
            {
                juego.SetActive(false);
                tiempoRestante.text = "-Tiempo: " + (300 - tiempo).ToString("00:00");
                gameOver.SetActive(true);
            }
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
    }
}
