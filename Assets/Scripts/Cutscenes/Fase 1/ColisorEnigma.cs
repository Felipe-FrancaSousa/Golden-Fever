using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorEnigma : MonoBehaviour
{
    public GameObject canvas;
    private void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.layer
            == LayerMask.NameToLayer("Player"))
        {
            canvas.GetComponent<cena>().chegouEnigma = true;
            Destroy(this);
        }
    }
}
