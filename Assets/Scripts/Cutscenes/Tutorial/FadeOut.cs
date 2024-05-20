using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public Image imagem;

    public GameObject telaPreta;
    public GameObject legenda;

    public TextMeshProUGUI textoCima;
    public TextMeshProUGUI textoBaixo;

    private string[] textoTotal =
    {
        "Museu Arqueológico",
        "\n14 de maio de 1974"
    };

    private string textoAtual;

    public float delay;

    public bool fim;

    // Start is called before the first frame update
    void Start()
    {
        legenda.SetActive(true);
        telaPreta.SetActive(true);

        textoCima.text = "";
        textoBaixo.text = "";

        StartCoroutine(fadeOut());
    }

    // Update is called once per frame
    IEnumerator fadeOut()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i <= textoTotal[0].Length; i++)
        {
            textoAtual = textoTotal[0].Substring(0, i);
            textoCima.text = textoAtual;
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i <= textoTotal[1].Length; i++)
        {
            textoAtual = textoTotal[1].Substring(0, i);
            textoBaixo.text = textoAtual;
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(2);
        textoCima.CrossFadeAlpha(0, 2, false);
        textoBaixo.CrossFadeAlpha(0, 2, false);
        yield return new WaitForSeconds(1);
        imagem.CrossFadeAlpha(0, 2, false);

        // Final

        yield return new WaitUntil(() => fim);
        imagem.CrossFadeAlpha(1, 2, false);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Fase1");
    }
}