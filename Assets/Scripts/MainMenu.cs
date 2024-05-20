using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject login;
    public string caminho;

    private void Awake()
    {
        Cursor.visible = true;

        DadosLogin dados = SavingSystem.CarregarLogin();

        if (dados != null)
        {
            ControladorDoJogo.username = dados.username;
            ControladorDoJogo.idUsername = dados.id;

            Debug.Log("ID: " + ControladorDoJogo.idUsername);

            login.GetComponent<Login>().ChamarLogin(true, ControladorDoJogo.idUsername);
        }

    }


    public void PlayGame()
    {
        ControladorDoJogo.dadosCarregados = null;
        ControladorDoJogo.novoJogo = true;
        Pontuacao.pontosAtuais = 0;
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame()
    {
        SavingSystem.SalvarLogin(ControladorDoJogo.idUsername, ControladorDoJogo.username);
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void LoadGame()
    {

        ControladorDoJogo.dadosCarregados = SavingSystem.Carregar();
        if(ControladorDoJogo.dadosCarregados != null)
        {
            Time.timeScale = 1f;
            PauseMenu.EstaPausado = false;
            ControladorDoJogo.novoJogo = false;
            ControladorDoJogo.CarregandoFase(ControladorDoJogo.dadosCarregados.nomeFase);
        }
    }

}
