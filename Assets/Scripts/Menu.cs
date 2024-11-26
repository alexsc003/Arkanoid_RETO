using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
