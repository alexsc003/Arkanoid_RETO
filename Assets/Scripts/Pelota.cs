using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    [SerializeField]
    private Vector3 initialVelocity;
    [SerializeField]
    GameObject juego;
    [SerializeField]
    GameObject jugador;
    [SerializeField]
    GameObject pelota;
    private Rigidbody ballRb;
    private bool isBallMoving;
    float numeroDeVidas;
        
    void Update()
    {
        if (juego.activeSelf)
        {                      
                if (Input.GetKeyDown(KeyCode.Space) && !isBallMoving)
                { 
                    transform.parent = null;
                    gameObject.GetComponent<Rigidbody>().AddForce(0,700,0);
                    isBallMoving = true;               
                }
            Debug.Log(numeroDeVidas);
        }
    }
    void OnCollisionEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            numeroDeVidas = numeroDeVidas - 1;
            isBallMoving = false;
        }
    }
}
