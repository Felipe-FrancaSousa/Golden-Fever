using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InserirPontuacao : MonoBehaviour
{
    private string url = "goldenfever.tk//scriptJogo//inserir.php";

    public bool insere;

    void Start()
    {
        StartCoroutine(Inserir());
        Debug.Log("oi de novo");
    }

    IEnumerator Inserir()
#pragma warning disable 618
    {
        yield return new WaitUntil(() => insere);
        WWWForm form = new WWWForm();
        form.AddField("usuario", ControladorDoJogo.idUsername);
        form.AddField("pontuacao", Pontuacao.pontosAtuais);
        WWW www = new WWW("http://" + url, form);
        yield return www;

        if (www.error == null)
        {
            if (www.text[0] == '0')
            {
                Debug.Log("Foi essa bagaça");
            }
            else
            {
                Debug.Log("Não foi essa bagaça" + www.text[0]);
            }
        }
    }
}
