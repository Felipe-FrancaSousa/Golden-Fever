using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Checkpoint : MonoBehaviour
{

    bool ativado;
    GameObject playerObjeto;
    GameObject armaObjeto;

    
    void Awake()
    {
        ativado = false;
    }


    void OnTriggerEnter2D(Collider2D colisor)
    {
       

        if (!ativado)
        {
            if (colisor.gameObject.layer
                == LayerMask.NameToLayer("Player"))
            {
                Ativar(colisor);
            }
        }
    }

    void Ativar(Collider2D colisor)
    {
        GetComponent<Animator>().SetTrigger("Ativado");
        ativado = true;

        
        armaObjeto = GameObject.FindGameObjectWithTag("Arma");

        playerObjeto = GameObject.FindGameObjectWithTag("Player");
        Health vida = playerObjeto.GetComponent<Health>();
        ScriptArma arma = armaObjeto.GetComponent<ScriptArma>();
        string fase = SceneManager.GetActiveScene().name;
        int pontos = Pontuacao.pontosAtuais;

        SavingSystem.Salvar(playerObjeto, vida, arma, fase, pontos);
        //Health jogador = colisor.GetComponent<Health>();
        //jogador.aoMorrer += mortePlayer;
    }
    /*
    void mortePlayer()
    {
        if (ControleDeCheckpoint.Instance.CurCheckPoint == this)
        {
            aoRespawnar.Invoke();
        }
    }
    */
}
