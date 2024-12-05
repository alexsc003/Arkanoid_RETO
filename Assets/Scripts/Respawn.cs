using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Inversion"))
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("Destruccion"))
        {
            Destroy(col.gameObject);
        }
    }
}
