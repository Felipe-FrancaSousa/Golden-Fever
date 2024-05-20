using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGalinha : MonoBehaviour
{
    public int vida;

    public float distanciaRecuar;

    public float distanciaDeAggro;

    public Transform proximaParada;

    private float tempoDeEspera;

    public float tempoDeEsperaInicial;

    private float minX;

    private float maxX;

    private float minY;

    private float maxY;

    public int offsetDeMovimento;

    public int contadorDePatrulha = 1;

    public float velocidade;

    public GameObject Frango;

    public int PontosGalinha;

    [HideInInspector]

    public Transform player;

    private Animator anima;

    
    

    public void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        anima = GetComponent<Animator>();

        minX = transform.position.x - offsetDeMovimento;
        minY = transform.position.y - offsetDeMovimento;
        maxX = transform.position.x + offsetDeMovimento;
        maxY = transform.position.y + offsetDeMovimento;
        proximaParada.position = transform.position;
        tempoDeEspera = tempoDeEsperaInicial;
        gerarParadas();

    }
    private void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) >= distanciaDeAggro)
            {
                transform.position = Vector2.MoveTowards(transform.position, proximaParada.position, velocidade * Time.deltaTime);

                if (Vector2.Distance(transform.position, proximaParada.position) < 0.2f)
                {
                    if (tempoDeEspera <= 0)
                    {
                        gerarParadas();
                        anima.Play("GalinhaAndando");
                        tempoDeEspera = tempoDeEsperaInicial;
                    }
                    else
                    {
                        tempoDeEspera -= Time.deltaTime;
                        anima.Play("GalinhaParada");
                    }
                }
            }
            else
            {

                if (Vector2.Distance(transform.position, player.position) < distanciaRecuar)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, -velocidade * Time.deltaTime);
                }

            }

        }  
    }

    void gerarParadas()
    {

        if (contadorDePatrulha == 1)
        {
            proximaParada.position = new Vector2(maxX, maxY);
            contadorDePatrulha++;

        }
        else if (contadorDePatrulha == 2)
        {
            proximaParada.position = new Vector2(maxX, minY);
            contadorDePatrulha++;

        }
        else if (contadorDePatrulha == 3)
        {
            proximaParada.position = new Vector2(minX, minY);
            contadorDePatrulha++;

        }
        else if (contadorDePatrulha == 4)
        {
            proximaParada.position = new Vector2(maxX, minY);
            contadorDePatrulha = 1;
        }

    }
    public void DanoNaGalinha(int dano)
    {
        vida -= dano;
       
        if (vida <= 0)
        {
            anima.Play("GalinhaMorta");
            gameObject.GetComponent<ScriptGalinha>().enabled = false;
            
            
        }

    }
    public void Morte()
    {
        Pontuacao.Pontuar(PontosGalinha);
        Destroy(gameObject);
        
    }
    public void DropFrango()
    {
        Instantiate(Frango, transform.position, transform.rotation);
    }

}
