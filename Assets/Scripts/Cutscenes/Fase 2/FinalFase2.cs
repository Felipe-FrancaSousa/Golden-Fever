﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFase2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas;
    private void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.layer
            == LayerMask.NameToLayer("Player"))
        {
            canvas.GetComponent<cenaFase2>().final = true;
        }
    }
}