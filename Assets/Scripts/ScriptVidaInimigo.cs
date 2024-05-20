using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptVidaInimigo : MonoBehaviour
{
    public int vida;
    void Start()
    {
    }
    public void DanoNoInimigo (int dano)
    {
        vida -= dano;

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

}
