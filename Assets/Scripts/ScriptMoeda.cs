using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptMoeda : MonoBehaviour
{
    public int PontosMoeda;
    public AudioSource Audio;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Audio.Play();
            Destroy(gameObject);
            Pontuacao.Pontuar(PontosMoeda);
        }
    }

}
