using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ControladorDeFase : MonoBehaviour
{
    public GameObject telaDeMorte;
    public GameObject ponteiroMira;
    public GameObject hudUI;
    public static bool estaMorto;
    void Awake()
    {
        Time.timeScale = 1f;
        PauseMenu.EstaPausado = false;
        telaDeMorte.SetActive(false);
        estaMorto = false;

        if (ControladorDoJogo.dadosCarregados != null)
        {
            CarregandoDados();
        }
    }
 
    public static void CarregandoDados()
    {
     
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject arma = GameObject.FindGameObjectWithTag("Arma");

        Vector3 posicaoPlayer = new Vector3(ControladorDoJogo.dadosCarregados.posicaox, ControladorDoJogo.dadosCarregados.posicaoy, ControladorDoJogo.dadosCarregados.posicaoz);
        player.transform.position = posicaoPlayer;
        player.GetComponent<Health>().vidaAtual = ControladorDoJogo.dadosCarregados.vida;
        arma.GetComponent<ScriptArma>().municaoAtual = ControladorDoJogo.dadosCarregados.balas;
        Pontuacao.pontosAtuais = ControladorDoJogo.dadosCarregados.pontosSalvos;
        
    }

    public void aoMorrer()
    {
        telaDeMorte.SetActive(true);
        Cursor.visible = true;
        ponteiroMira.SetActive(false);
        hudUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void TentarNovamente()
    {
        ControladorDoJogo.dadosCarregados = SavingSystem.Carregar();
        ControladorDoJogo.CarregandoFase(ControladorDoJogo.dadosCarregados.nomeFase);
        CarregandoDados();

    }


    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
