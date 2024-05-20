using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBala : MonoBehaviour
{
    public float velocidade;
    public int TempoDeVidaBala;
    public Rigidbody2D rb;
    public int danoDaBala;


    void Start()
    {
        rb.velocity = transform.right * velocidade;
        Invoke("DestruirProjetil", TempoDeVidaBala);
    }
    void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.tag == "Enemy")
        {
            colisao.GetComponent<FuncoesInimigo>().DanoNoInimigo(danoDaBala);
            DestruirProjetil();

        }else if (colisao.tag == "Galinha")
        {
            colisao.GetComponent<ScriptGalinha>().DanoNaGalinha(danoDaBala);
            DestruirProjetil();
        }
        else if (colisao.tag == "Cenário")
            DestruirProjetil();
        }
    void DestruirProjetil()
    {
        Destroy(gameObject);
    }

}
