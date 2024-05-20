using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class cena : MonoBehaviour
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

    public bool chegouInimigos = false;
    public bool chegouMedkit = false;
    public bool pegouJoia = false;
    public bool chegouTemplo = false;
    public bool chegouEnigma = false;
    public bool chegouArtefato = false;
    public bool chegouFinal = false;

    public bool final;

    private string e = "Aperte E";

    private string[] cena1 =
    {
        "Ok, bem-vindo ao Peru",
        "A partir de agora, você ficará por conta própria",
        "Explore o cenário em busca de artefatos que possam ser\nidentificados",
        "Passe por cima dele e automaticamente será adicionado\nno seu diário",
        "Aliás",
        "Está vendo essa fogueira a frente?",
        "Ela é um checkpoint",
        "Passe perto e ela acenderá, salvando seu progresso",
        "Assim, toda vez que sair do jogo, manterá seu progresso\nsalvo",
        "Boa sorte"
    };

    private string[] cena2 =
    {
        "Bem como eu suspeitava",
        "Isso é um acampamento de bandidos",
        "Significa que pode encontrar perigo a frente a partir de agora",
        "Esses bandidos estão armados com fuzis, e atirarão sem mesmo se preocuparem quem você é",
        "Por sorte tem um jeito mais fácil de desviar dos projéteis dele",
        "Você pode apertar espaço enquanto anda para dar um rolamento na direção que está indo",
        "Enquanto rola, os projéteis não causarão dano a você",
        "Existe um intervalo de tempo entre um rolamento e outro, então tome cuidado"
    };

    private string[] cena3 =
    {
        "Nossa, você está bem? Foi uma briga e tanto",
        "Se machucou?",
        "Ah, tudo bem. Tem um kit de primeiros socorros logo a frente",
        "Passe por ele para curar a vida",
        "Bem, acho que agora está melhor",
        "E como vai a exploração? Achou algum artefato?",
        "Ah, não se preocupe, sua jornada acabou de começar",
        "Ainda tem muito trabalho pela frente",
        "Se precisar de alguma coisa...",
        "... não me ligue",
        "Até porque você nem tem o meu número"
    };

    private string[] cena4 =
    {
        "Olha, parece que você pegou sua primeira jóia",
        "Estava bem protegida, não?",
        "Você pode dar uma olhada nela e nas suas características abrindo o journal",
        "Boa sorte para encontrar o restante das relíquias"
    };

    private string[] cena5 =
    {
        "Você chegou no primeiro templo",
        "Pode ser que encontre artefatos aí dentro",
        "Claro, se os contrabandistas não pegaram primeiro",
        "Enfim, tome cuidado e boa sorte"
    };

    private string[] cena6 =
    {
        "Veja! A passagem está fechada",
        "Você vai ter que resolver um enigma para abri-la",
        "Hmm",
        "Ao que parece, você precisa atirar nos totens em uma ordem certa",
        "Agora, qual é a ordem?",
        "Se eu não me engano é:\nDireita, esquerda e baixo",
        "Tente agora"
    };

    private string[] cena7 =
    {
        "Olha!",
        "Seu primeiro artefato",
        "Isso deve ter um grande valor cultural",
        "É bom que tenha encontrado"
    };

    private string[] cena8 =
    {
        "Parece que você chegou ao fim da sua primeira missão",
        "Os dois itens que você coletou serão muito importantes para o museu",
        "Estou orgulhoso de você",
        "Agora pode progredir",
        "O helicóptero te levará ao segundo local de exploração",
        "Bom trabalho"
    };

    void Start()
    {
        fundoPreto.SetActive(true);

        eCima.text = "";
        eBaixo.text = "";

        AndarPlayer(false);
        Player.GetComponent<PlayerControl>().rolamentoBloqueado = true;

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
        StartCoroutine(Cena2());
        StartCoroutine(Cena3());
        StartCoroutine(Cena4());
        StartCoroutine(Cena5());
        StartCoroutine(Cena6());
        StartCoroutine(Cena7());
        StartCoroutine(Cena8());

        yield return new WaitUntil(() => final);
        fundoPreto.GetComponent<Image>().CrossFadeAlpha(1, 2, false);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Fase2");
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

    // Cena 2

    IEnumerator Cena2()
    {
        yield return new WaitUntil(() => chegouInimigos);

        AndarPlayer(false);
        animacao.Play("PlayerIdleUp");

        eBaixo.text = "";
        painelDialogo.SetActive(true);

        for (int i = 0; i < cena2.Length; i++)
        {
            for (int j = 0; j <= cena2[i].Length; j++)
            {
                dialogo.text = cena2[i].Substring(0, j);
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
        Player.GetComponent<PlayerControl>().rolamentoBloqueado = false;
    }

    // Cena 3

    IEnumerator Cena3()
    {
        yield return new WaitUntil(() => chegouMedkit);

        AndarPlayer(false);
        animacao.Play("PlayerIdleUp");

        eBaixo.text = "";
        painelDialogo.SetActive(true);

        for (int i = 0; i < cena3.Length; i++)
        {
            for (int j = 0; j <= cena3[i].Length; j++)
            {
                dialogo.text = cena3[i].Substring(0, j);
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

    IEnumerator Cena4()
    {
        yield return new WaitUntil(() => pegouJoia);

        AndarPlayer(false);
        animacao.Play("PlayerIdleUp");

        eBaixo.text = "";
        painelDialogo.SetActive(true);

        for (int i = 0; i < cena4.Length; i++)
        {
            for (int j = 0; j <= cena4[i].Length; j++)
            {
                dialogo.text = cena4[i].Substring(0, j);
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

    // Cena 5

    IEnumerator Cena5()
    {
        yield return new WaitUntil(() => chegouTemplo);

        AndarPlayer(false);
        animacao.Play("PlayerIdleUp");

        eBaixo.text = "";
        painelDialogo.SetActive(true);

        for (int i = 0; i < cena5.Length; i++)
        {
            for (int j = 0; j <= cena5[i].Length; j++)
            {
                dialogo.text = cena5[i].Substring(0, j);
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

    IEnumerator Cena6()
    {
        yield return new WaitUntil(() => chegouEnigma);

        AndarPlayer(false);
        animacao.Play("PlayerIdleUp");

        eBaixo.text = "";
        painelDialogo.SetActive(true);

        for (int i = 0; i < cena6.Length; i++)
        {
            for (int j = 0; j <= cena6[i].Length; j++)
            {
                dialogo.text = cena6[i].Substring(0, j);
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

    // Cena 7

    IEnumerator Cena7()
    {
        yield return new WaitUntil(() => chegouArtefato);

        AndarPlayer(false);
        animacao.Play("PlayerIdleUp");

        eBaixo.text = "";
        painelDialogo.SetActive(true);

        for (int i = 0; i < cena7.Length; i++)
        {
            for (int j = 0; j <= cena7[i].Length; j++)
            {
                dialogo.text = cena7[i].Substring(0, j);
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

    // Cena 8

    IEnumerator Cena8()
    {
        yield return new WaitUntil(() => chegouFinal);

        AndarPlayer(false);
        animacao.Play("PlayerIdleUp");

        eBaixo.text = "";
        painelDialogo.SetActive(true);

        for (int i = 0; i < cena8.Length; i++)
        {
            for (int j = 0; j <= cena8[i].Length; j++)
            {
                dialogo.text = cena8[i].Substring(0, j);
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

        final = true;
    }
}
