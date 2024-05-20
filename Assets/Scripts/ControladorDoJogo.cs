using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDoJogo : MonoBehaviour
{

    /* Contextulizando, esse é um script onde você
    pode colocar todas as funções e variáveis que precisam ser
    salvar entre fases e cenas.
    */

    private static ControladorDoJogo instancia;
    public static DadosPlayer dadosCarregados;
    public static bool novoJogo = false;

    public static string username;
    public static int idUsername;
    public static int maiorPontuacao;
    public static bool estaLogado { get { return username != null; } }


    void Awake()
    {
        if(instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(instancia);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public static void CarregandoFase(string fase)
    {
        SceneManager.LoadScene(fase);
    }

}

