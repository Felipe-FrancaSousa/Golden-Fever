using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetScore : MonoBehaviour
{
    public GameObject Username;
    public GameObject Data;
    public GameObject Pontuacao;

    public void GravarPontuacao(string username, string data, string pontuacao)
    {
        string txtUsername = username;
        Username.GetComponent<TextMeshProUGUI>().text = txtUsername;
        Data.GetComponent<TextMeshProUGUI>().text = data;
        Pontuacao.GetComponent<TextMeshProUGUI>().text = pontuacao;
    }
}
