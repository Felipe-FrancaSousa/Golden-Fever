using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorInimigos : MonoBehaviour
{
    public GameObject canvas;
    private void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.layer
            == LayerMask.NameToLayer("Player"))
        {
            canvas.GetComponent<cena>().chegouInimigos = true;
            Destroy(this);
        }
    }
}
