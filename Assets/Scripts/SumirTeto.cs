using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class SumirTeto : MonoBehaviour
{

    public GameObject teto;
    public Tilemap TmTeto;
    public Musicas Musica;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Musica.MusicasAmbiente[0].Stop();
            Musica.MusicasAmbiente[1].Play();
            StartCoroutine("FadeOut");
        }


    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Musica.MusicasAmbiente[0].Play();
            Musica.MusicasAmbiente[1].Stop();
            StartCoroutine("FadeIn");
        }

    }

    IEnumerator FadeOut()
    {   
        for(float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = TmTeto.color;
            c.a = f;
            TmTeto.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeIn()
    {
        for (float f = -0.05f; f <= 1.5f; f += 0.05f)
        {
            Color c = TmTeto.color;
            c.a = f;
            TmTeto.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
