using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class DadosPlayer
{
    public float posicaox;
    public float posicaoy;
    public float posicaoz;
    public double vida;
    public int balas;
    public string nomeFase;
    public int pontosSalvos;


    public DadosPlayer(GameObject player, Health health, ScriptArma arma, string fase, int pontos)
    {
        posicaox = player.transform.position.x;
        posicaoy = player.transform.position.y;
        posicaoz = player.transform.position.z;
        nomeFase = fase;
        vida = health.vidaAtual;
        balas = arma.municaoAtual;
        pontosSalvos = pontos;
    }
}
