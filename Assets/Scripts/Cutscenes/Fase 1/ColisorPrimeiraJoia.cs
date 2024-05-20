using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorPrimeiraJoia : MonoBehaviour
{
    public GameObject canvas;
    private void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.layer
            == LayerMask.NameToLayer("Player"))
        {
            canvas.GetComponent<cena>().pegouJoia = true;
            Destroy(this);
        }
    }
}
