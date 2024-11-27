using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloques : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip chocar;

    [SerializeField]
    private AudioClip destruir;

    [SerializeField]
    float puntosDeVida;

    [SerializeField]
    float puntos;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("ball"))
        { 
            if (puntosDeVida == 0)
            {
                Destroy(gameObject);
               // SumarPuntos()
               audioSource.PlayOneShot(destruir);
            }
            else 
            {
               puntosDeVida = puntosDeVida - 1;
               audioSource.PlayOneShot(chocar);
            }
        }
    }
   /* void SumarPuntos()
    {

    }*/
}
