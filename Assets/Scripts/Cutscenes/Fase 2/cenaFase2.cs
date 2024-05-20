using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class cenaFase2 : MonoBehaviour
{
    public GameObject fundoPreto;
    public GameObject Player;

    public TextMeshProUGUI dialogo;
    public GameObject painelDialogo;

    public TextMeshProUGUI dialogoCima;
    public GameObject painelDialogoCima;

    public TextMeshProUGUI eCima;
    public TextMeshProUGUI eBaixo;

    public TextMeshProUGUI instrucao;
    public GameObject painelInstrucao;

    private Animator animacao;

    public float delayTexto = 0.025f;

    public bool final;

    private string e = "Aperte E";

    private string[] cena1 =
    {
        "Bem vindo a sua segunda missão",
        "As instruções aqui são as mesmas da missão anterior",
        "Portanto, creio que não terá dificuldades",
        "Vou te interromper menos dessa vez",
        "Boa sorte"
    };
    void Start()
    {
        fundoPreto.SetActive(true);

        eCima.text = "";
        eBaixo.text = "";

        AndarPlayer(false);
        Player.GetComponent<PlayerControl>().rolamentoBloqueado = false;

        animacao = Player.GetComponent<Animator>();

        painelDialogo.SetActive(false);
        painelDialogoCima.SetActive(false);
        painelInstrucao.SetActive(false);

        StartCoroutine(FadeOutIn());
    }

    void AndarPlayer(bool status)
    {
        Player.GetComponent<PlayerControl>().andarBloqueado = !status;

        if (status == false)
        {
            Player.GetComponent<PlayerControl>().moveSpeed = 0;
            Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        else
        {
            // Player.GetComponent<PlayerControl>().moveSpeed = 15f;
            Player.GetComponent<PlayerControl>().moveSpeed = 4.5f;
            animacao.Play("Idle Animation");
        }
    }

    IEnumerator FadeOutIn()
    {
        yield return new WaitForSeconds(0.5f);
        fundoPreto.GetComponent<Image>().CrossFadeAlpha(0, 2, false);

        StartCoroutine(Cena1());

        yield return new WaitUntil(() => final);
        fundoPreto.GetComponent<Image>().CrossFadeAlpha(1, 2, false);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu");
    }

    // Cena 1

    IEnumerator Cena1()
    {
        yield return new WaitForSeconds(1.5f);

        eBaixo.text = "";
        painelDialogo.SetActive(true);

        for (int i = 0; i < cena1.Length; i++)
        {
            for (int j = 0; j <= cena1[i].Length; j++)
            {
                dialogo.text = cena1[i].Substring(0, j);
                yield return new WaitForSeconds(delayTexto);
            }

            for (int j = 0; j <= e.Length; j++)
            {
                eBaixo.text = e.Substring(0, j);
                yield return new WaitForSeconds(delayTexto);
            }

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            yield return new WaitForEndOfFrame();

            eBaixo.text = "";
        }

        painelDialogo.SetActive(false);

        AndarPlayer(true);
    }


}
