using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    GameObject bolaDestructora;

    [SerializeField]
    Material normalJugador;

    [SerializeField]
    Material bolaColorNormal;

    [SerializeField]
    Material bolaColorDestruccion;
    [SerializeField]
    Material InversoJugador;

    [SerializeField]
    GameObject Pelota;

    [SerializeField]
    GameObject activaMejora;

    float tiempoMejora;
    float tiempoDestruccion;

    [SerializeField]
    GameObject juego;

    [SerializeField]
    GameObject jugador;

    float movimientoEjeX;
    float velocidadMovimiento = 10;
    void Update()
    {
        if(juego.activeSelf)
        {
            movimientoEjeX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidadMovimiento;
            transform.Translate(movimientoEjeX, 0, 0);
            if (transform.position.x < -6) transform.position = new Vector3(-6f, -3.5f, 0);
            if (transform.position.x > 6) transform.position = new Vector3(6f, -3.5f, 0);
        }
        if (activaMejora.activeSelf)
        {
            tiempoMejora = tiempoMejora + Time.deltaTime;
            if (tiempoMejora > 10)
            {
                activaMejora.SetActive(false);
                tiempoMejora = 0;
                velocidadMovimiento = 10;
                gameObject.GetComponent<MeshRenderer>().material = normalJugador;
            }
        }
        if (bolaDestructora.activeSelf)
        {
            tiempoDestruccion = tiempoDestruccion + Time.deltaTime;
            if (tiempoDestruccion > 10)
            {
                Pelota.GetComponent<MeshRenderer>().material = bolaColorNormal;
                bolaDestructora.SetActive(false);
                tiempoDestruccion = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Inversion"))
        {
            velocidadMovimiento = -10;
            tiempoMejora = 0;
            activaMejora.SetActive(true);
            gameObject.GetComponent<MeshRenderer>().material = InversoJugador;
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("Destruccion"))
        {
            tiempoMejora = 0;
            bolaDestructora.SetActive(true);
            Pelota.GetComponent<MeshRenderer>().material = bolaColorDestruccion ;
            Destroy(col.gameObject);
        }
    }
}
