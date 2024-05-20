using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pontuacao : MonoBehaviour
{
    public static int pontosAtuais = 0;
    TextMeshProUGUI TextoPontuacao;
    // Start is called before the first frame update
    void Start()
    {
        TextoPontuacao = GetComponent<TextMeshProUGUI>();
    }

    public static void Pontuar(int ponto)
    {
        pontosAtuais += ponto;
    }

    // Update is called once per frame
    void Update()
    {
        TextoPontuacao.text = pontosAtuais.ToString();
    }
}
