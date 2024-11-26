using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloques : MonoBehaviour
{
    private void OnCollisionEnter(Collider col)
    {
        if (col.gameObject.CompareTag("ball"))
        { 
        Destroy(col.gameObject);
        }
    }
}
