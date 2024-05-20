using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExibirPontuacao : MonoBehaviour
{
    private string urlScript = "goldenfever.tk//scriptJogo//script.php";
    private List<Jogador> jogadores = new List<Jogador>();
    private string[] arrayPHP = null;

    public Transform tfPainelCarregarDados;
    public TextMeshProUGUI txtCarregando;
    public GameObject PanelPre;

    public TextMeshProUGUI user;
    public TextMeshProUGUI melhorPont;
    public TextMeshProUGUI pontAtual;

    private void Start()
    {
        StartCoroutine(ObterJogadores());
        ExibirInformacoes();
    }

    IEnumerator ObterJogadores()
#pragma warning disable 618
    {
        txtCarregando.text = "Carregando...";
        WWW www = new WWW("http://" + urlScript);
        yield return www;

        if (www.error != null)
        {
            Debug.Log("Erro ao acessar a base: " + www.error);
        }
        else
        {
            txtCarregando.text = "";
            ObterRegistros(www);
            ExibirRegistros();
        }
    }

    public void ObterRegistros(WWW www)
    {
        arrayPHP = System.Text.Encoding.UTF8.GetString(www.bytes).Split(";"[0]);

        for (int i = 0; i < arrayPHP.Length - 4; i = i + 3)
        {
            jogadores.Add(new Jogador(arrayPHP[i], arrayPHP[i + 1], arrayPHP[i + 2]));
            //Debug.Log(i);
        }
    }

    public void ExibirRegistros()
    {
        for (int i = 0; i < jogadores.Count; i++)
        {
            GameObject obj = Instantiate(PanelPre);
            Jogador jg = jogadores[i];

            string u = jg.username;
            string d = jg.data;
            string p = jg.pontuacao;

            obj.GetComponent<SetScore>().GravarPontuacao(u, d, p);
            obj.transform.SetParent(tfPainelCarregarDados);
            obj.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

            ExibirInformacoes();
        }
    }

    public void ExibirInformacoes()
    {
        if (ControladorDoJogo.username != null)
        {
            user.text = ControladorDoJogo.username;
            melhorPont.text = ControladorDoJogo.maiorPontuacao.ToString();
            pontAtual.text = Pontuacao.pontosAtuais.ToString();
        }
    }
}

public class Jogador
{
    public string username;
    public string data;
    public string pontuacao;

    public Jogador(string username, string data, string pontuacao)
    {
        this.username = username;
        this.data = data;
        this.pontuacao = pontuacao;
    }
}
