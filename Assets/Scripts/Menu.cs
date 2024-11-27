using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject juego;
   public void Jugar()
    {
        menu.SetActive(false);
        juego.SetActive(true);
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene("Arkane");
    }
}
