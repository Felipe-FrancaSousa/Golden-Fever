using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBalaInimigo : MonoBehaviour
{
    public float velocidade;

    public float TempoDeVida;

    public float dano;

    public bool estaRolando;
    void Start()
    {
        Invoke("DestruirProjetil", TempoDeVida);  
    }

    void Update()
    {
        estaRolando = PlayerControl.rolling;
        transform.Translate(Vector2.up * velocidade * Time.deltaTime);
    }

    void DestruirProjetil()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D colisao)
    {
        if(colisao.tag == "Player")
        {
            if (!estaRolando)
            {
            colisao.GetComponent<Health>().DanoNoPlayer();
            DestruirProjetil();
            }
           
        }
        else if(colisao.tag == "Cenário")
        {
            Destroy(gameObject);
        }
    }
}
