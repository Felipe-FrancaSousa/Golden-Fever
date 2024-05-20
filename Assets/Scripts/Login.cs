using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    private string urlScript = "www.goldenfever.tk/conta/login/login.act.php";

    public GameObject painelLogin;
    public GameObject painelUsuario;

    public TMP_InputField campoUsername;
    public TMP_InputField campoSenha;

    public TextMeshProUGUI log;

    public Button botaoLogin;

    public TextMeshProUGUI usuarioLogado;
    public TextMeshProUGUI maiorPontuacao;
    public TextMeshProUGUI pontuacao;

    private string[] arrayPHP = null;

    void Start()
    {
        usuarioLogado.text = "";
        log.text = "";

        if (ControladorDoJogo.username == null)
        {
            painelLogin.SetActive(true);
            painelUsuario.SetActive(false);
        }
        else
        {
            painelLogin.SetActive(false);
            painelUsuario.SetActive(true);
            usuarioLogado.text = ControladorDoJogo.username;
        }
    }

/*public void ChamarLogin(bool adm, int id)
    {
        StartCoroutine(FazerLogin(adm, id));
    }*/

    public void ChamarLogin(bool adm, int id)
    {
        StartCoroutine(FazerLogin(adm, id));
    }

    public void BotaoChamarLogin()
    {
        StartCoroutine(FazerLogin(false, 0));
    }

    
    IEnumerator FazerLogin(bool adm, int idUsername)
#pragma warning disable 618
    {
        campoUsername.interactable = false;
        campoSenha.interactable = false;

        log.text = "Carregando";
        log.color = new Color32(255, 255, 255, 255);

        WWWForm form = new WWWForm();

        if (adm)
        {
            form.AddField("id", idUsername);
            form.AddField("adm", "SenhaDeAdministradorParaConseguirFazerLoginSemASenhaDoUsuario");
        }
        else
        {
            form.AddField("username", campoUsername.text);
            form.AddField("senha", campoSenha.text);
        }
        

#pragma warning disable 618
        WWW www = new WWW("http://" + urlScript, form);

        yield return www;

#pragma warning disable 618
        if (www.text[0] == '0')
        {
            arrayPHP = System.Text.Encoding.UTF8.GetString(www.bytes).Split(";"[0]);

            if (!adm)
            {
                ControladorDoJogo.username = campoUsername.text;
                ControladorDoJogo.idUsername = int.Parse(arrayPHP[1]);
                ControladorDoJogo.maiorPontuacao = int.Parse(arrayPHP[2]);
            }
            else
            {
                ControladorDoJogo.maiorPontuacao = int.Parse(arrayPHP[1]);
            }

            Debug.Log("Usuário " + ControladorDoJogo.username + " logado");
            painelLogin.SetActive(false);
            painelUsuario.SetActive(true);

            usuarioLogado.text = ControladorDoJogo.username;
            pontuacao.text = Pontuacao.pontosAtuais.ToString();
            maiorPontuacao.text = ControladorDoJogo.maiorPontuacao.ToString();
        }
        else if (www.text[0] == '1')
        {
            log.text = "Usuário ou senha inválidos";
            Debug.Log("1");
            //log.faceColor = new Color32(255, 30, 30, 255);
            log.color = new Color32(255, 30, 30, 255);

            campoUsername.interactable = true;
            campoSenha.interactable = true;
        }
        else
        {
            log.text = "Falha ao acessar a base de dados";
            //log.faceColor = new Color32(255, 30, 30, 255);
            log.color = new Color32(255, 30, 30, 255);
            Debug.Log(www.text[0]);

            campoUsername.interactable = true;
            campoSenha.interactable = true;
        }
    }

    public void VerificarCampos()
    {
        botaoLogin.interactable = (campoUsername.text.Length > 0 && campoSenha.text.Length > 0);
    }

    public void Cadastrar()
    {
        Application.OpenURL("http://www.goldenfever.tk/conta/login");
    }

    public void Logout()
    {
        ControladorDoJogo.username = null;
        ControladorDoJogo.idUsername = 0;
        ControladorDoJogo.maiorPontuacao = 0;
        Pontuacao.pontosAtuais = 0;
        painelUsuario.SetActive(false);
        painelLogin.SetActive(true);

        campoUsername.interactable = true;
        campoSenha.interactable = true;

        campoUsername.text = "";
        campoSenha.text = "";

        log.text = "";
    }
}
