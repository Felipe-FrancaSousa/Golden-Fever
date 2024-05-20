using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncoesInimigo : MonoBehaviour
{
    public int vida;

    public float velocidade;

    public float tempoEntreAtaques;

    public int pontosInimigo;

    public GameObject Sacola;

    public AudioSource AudioMorte;

    int ChanceDrop;

    Animator anim;

    [HideInInspector]

    public Transform player;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    public void DanoNoInimigo(int dano)
    {
        vida -= dano;

        if (vida <= 0)
        {

            GetComponent<ScriptInimigoPadrao>().enabled = false;
            anim.Play("InimigoMorte");   

        }
    }

    void Morte()
    {
        AudioMorte.Play();
        ChanceDrop = Random.Range(0,4);

        if(ChanceDrop == 1)
        {
            Instantiate(Sacola, transform.position, transform.rotation);
        }

        Pontuacao.Pontuar(pontosInimigo);
        Destroy(gameObject);
    }
    void Update()
    {
    }
}
