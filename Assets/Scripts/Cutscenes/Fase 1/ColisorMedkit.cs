using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorMedkit : MonoBehaviour
{
    public GameObject canvas;
    private void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.layer
            == LayerMask.NameToLayer("Player"))
        {
            canvas.GetComponent<cena>().chegouMedkit = true;
            Destroy(this);
        }
    }
}
