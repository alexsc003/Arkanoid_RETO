using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    GameObject juego;
    [SerializeField]
    GameObject jugador;
    float movimientoEjeX;
    public float velocidadMovimiento = 10;
    void Update()
    {
        if(juego.activeSelf)
        {
            
            movimientoEjeX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidadMovimiento;
            transform.Translate(movimientoEjeX, 0, 0);
            if (transform.position.x < -6) transform.position = new Vector3(-6f, -3.5f, 0);
            if (transform.position.x > 6) transform.position = new Vector3(6f, -3.5f, 0);
        }
    }
}
