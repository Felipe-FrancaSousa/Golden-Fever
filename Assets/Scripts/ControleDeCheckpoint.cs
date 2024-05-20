using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControleDeCheckpoint : MonoBehaviour
{/*
    DadosPlayer dadosCarregados;
    GameObject player;
    GameObject arma;
    Vector3 position;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        arma = GameObject.FindGameObjectWithTag("Arma");


        //SceneManager.LoadScene(dadosCarregados.nomeFase);
        //position = new Vector3(dadosCarregados.posicaox, dadosCarregados.posicaoy, dadosCarregados.posicaoz);
        player.transform.position = position;
        player.GetComponent<Health>().vidaAtual = dadosCarregados.vida;
        arma.GetComponent<ScriptArma>().municaoAtual = dadosCarregados.balas;
        
    }
    
    public List<Checkpoint> CheckPoints { get { return checkPoints; } }
    public Checkpoint CurCheckPoint {
        get {
            return checkPoints ? checkPoints[curIndex] : null;
        } 
}
    public static ControleDeCheckpoint Instance { get { return instance; } }

    List<Checkpoint> checkPoints = new List<Checkpoint>();

    int curIndex = 0;

    static ControleDeCheckpoint instance = null;

    protected void Awake(){

        instance = this;


        for (int i = 0; i < transform.childCount; ++i)
        {
            Checkpoint checkpoint = transform.GetChild(i).GetComponent<Checkpoint>();
            checkpoint.Ativar += OnCheckPointTriggered;
            checkPoints.Add(checkpoint);
        }
    }
    public void OnCheckPointTriggered(Checkpoint newCheckPoint)
    {
        curIndex = checkPoints.IndexOf(newCheckPoint);
    }*/
}
