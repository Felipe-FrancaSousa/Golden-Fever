using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class pausar1 : MonoBehaviour
{
    public GameObject canvas;

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.layer
            == LayerMask.NameToLayer("Player"))
        {
            canvas.GetComponent<Cena1>().chegou1 = true;
            //Destroy(gameObject);
        }
    }
}