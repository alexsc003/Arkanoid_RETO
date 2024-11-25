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
    float tiempo = 300;
    [SerializeField]
    TextMeshProUGUI contador;
    void Update()
    {
        if(juego.activeSelf)
        {
            
            movimientoEjeX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidadMovimiento;
            transform.Translate(movimientoEjeX, 0, 0);
            tiempo = tiempo - Time.deltaTime;
            contador.text = tiempo.ToString("000");
               
        }
    }
}
