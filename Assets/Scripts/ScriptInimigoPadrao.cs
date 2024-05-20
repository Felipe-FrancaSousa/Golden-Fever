using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptInimigoPadrao : FuncoesInimigo
{

    public float distanciaParar;

    public float distanciaRecuar;

    public float distanciaDeAggro;

    private float tempoDeAtaque;

    public Transform firepoint;

    public GameObject balaInimigo;

    public Transform proximaParada;

    private float tempoDeEspera;

    public float tempoDeEsperaInicial;

    private float minX;

    private float maxX;

    private float minY;

    private float maxY;

    public int offsetDeMovimento;

    public int contadorDePatrulha = 1;

    public AudioSource AudioTiro;


    public override void Start()
    {
        base.Start();
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
        if(player != null)
        {
            if (Vector2.Distance(transform.position, player.position) >= distanciaDeAggro)
            {
                transform.position = Vector2.MoveTowards(transform.position, proximaParada.position, velocidade * Time.deltaTime);

                if(Vector2.Distance(transform.position, proximaParada.position) < 0.2f)
                {
                    if(tempoDeEspera <= 0)
                    {
                        gerarParadas();
                        tempoDeEspera = Random.Range(2, 4);
                    }
                    else{
                        tempoDeEspera -= Time.deltaTime;
                    }
                }
            }else{

                if (Time.time >= tempoDeAtaque)
                {
                    tempoDeAtaque = Time.time + tempoEntreAtaques;
                    AtaqueADistancia();
                }

                if (Vector2.Distance(transform.position, player.position) > distanciaParar)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, velocidade * Time.deltaTime);
                }
                else if (Vector2.Distance(transform.position, player.position) < distanciaParar && Vector2.Distance(transform.position, player.position) > distanciaRecuar)
                {
                    transform.position = this.transform.position;
                }
                else if (Vector2.Distance(transform.position, player.position) < distanciaRecuar)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, -velocidade * Time.deltaTime);
                }
               
            }
            
        }
    }
    public void AtaqueADistancia()
    {
        Vector2 direcao = player.position - firepoint.position;
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        Quaternion rotacao = Quaternion.AngleAxis(angulo - 90, Vector3.forward);
        firepoint.rotation = rotacao;

        AudioTiro.Play();
        Instantiate(balaInimigo, firepoint.position, firepoint.rotation);
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
            proximaParada.position = new Vector2(minX, minY);
            contadorDePatrulha++;

        }
        else if (contadorDePatrulha == 3)
        {
            proximaParada.position = new Vector2(maxX, minY);
            contadorDePatrulha++;

        }
        else if (contadorDePatrulha == 4)
        {
            proximaParada.position = new Vector2(minX, maxY);
            contadorDePatrulha = 1;
        }

    }
}

       