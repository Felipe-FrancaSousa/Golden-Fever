using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool EstaPausado = false;

    public GameObject pauseMenuUI;
    public GameObject configOptionsUI;
    public GameObject pauseOptionsUI;
    public GameObject hudUI;
    public GameObject ponteiroMira;

    public bool hudBloqueado = false;


    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JournalScript.estaNoJournal || ControladorDeFase.estaMorto)
            {
                return;
            }

            if (EstaPausado )
            {
                
                configOptionsUI.SetActive(false);
                pauseOptionsUI.SetActive(true);
                continuar();
                
            } else {
                pausar();
            }      
        }
    }

    public void continuar()
    {
        Cursor.visible = false;
        ponteiroMira.SetActive(true);

        if (!hudBloqueado)
        {
            hudUI.SetActive(true);
        }

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        EstaPausado = false;
    }

    void pausar()
    {
        if (!hudBloqueado)
        {
            hudUI.SetActive(false);
        }
        Cursor.visible = true;
        ponteiroMira.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        EstaPausado = true;
    }

    public void carregarJogo()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CarregarDados()
    {

        ControladorDoJogo.dadosCarregados = SavingSystem.Carregar();
        ControladorDeFase.CarregandoDados();
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
       camera.GetComponent<CameraControl>().moverAoPlayer(camera);
    }
    public void sairJogo()
    {
        Application.Quit();
    }
}
