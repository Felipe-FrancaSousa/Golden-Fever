using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JournalScript : MonoBehaviour
{
    public static bool estaNoJournal = false;

    public GameObject JournalUI;
    public GameObject hudUI;
    public GameObject ponteiroMira;
    public bool DiarioBloqueado = false;
    public static bool[] GuardaSlot = new bool[8];

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (PauseMenu.EstaPausado || ControladorDeFase.estaMorto)
            {
                return;
            }
            if(!DiarioBloqueado)
            {
                if (estaNoJournal)
                {
                    continuar();
                }
                else
                {
                    ativar();
                }
            }
            else
            {
                return;
            }

        }
    }
    public void continuar()
    {
        estaNoJournal = false;
        Cursor.visible = false;
        ponteiroMira.SetActive(true);
        hudUI.SetActive(true);
        JournalUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void ativar()
    {
        estaNoJournal = true;
        Cursor.visible = true;
        ponteiroMira.SetActive(false);
        hudUI.SetActive(false);
        JournalUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void VerificaSlot()
    {

    }
}
