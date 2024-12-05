using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloques : MonoBehaviour
{
    [SerializeField]
    GameObject Destruccion;

    [SerializeField]
    GameObject vidas;
    
    [SerializeField]
    GameObject puntos;

    [SerializeField]
    GameObject bolaDestructora;
    float p;
    [SerializeField]
    GameObject mejora;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip chocar;

    [SerializeField]
    private AudioClip destruir;

    [SerializeField]
    float puntosDeVida;

    [SerializeField]
    int puntuacion;

    int iEscondite = -1;
    [SerializeField]
    GameObject Camara;
    float y;
    private void Start()
    {
        audioSource = Camara.GetComponent<AudioSource>();
        //Instantiate(mejora, new Vector3(0f, 0, 0), Quaternion.identity);
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("ball"))
        { 
            if (puntosDeVida <= 0)
            {
                y = Random.Range(1, 100);
                p = Random.Range(1, 100);
                audioSource.PlayOneShot(destruir);
                Pelota.instance.SumarPuntuacion(puntuacion);
                if (p < 20)
                {
                    Instantiate(mejora, transform.position, Quaternion.identity);
                }
                if (p > 80 )
                {
                    Instantiate(Destruccion, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
                if (y < 10)
                {
                    Instantiate(puntos, transform.position, Quaternion.identity);
                }
                
                if (y > 90)
                {
                    Instantiate(vidas, transform.position, Quaternion.identity);
                }
                

            }
            else 
            {
                if(bolaDestructora.activeSelf)
                { 
                puntosDeVida = puntosDeVida - 10000;
                    Pelota.instance.SumarPuntuacion(puntuacion);
                    audioSource.PlayOneShot(destruir);
                    Destroy(gameObject);
                }
                else
                {
                    puntosDeVida = puntosDeVida - 1;
                    audioSource.PlayOneShot(chocar);
                }
                   
            }
        }
    }
    public void SetEscondite(int escon)
    {
        iEscondite = escon;
    }
}
