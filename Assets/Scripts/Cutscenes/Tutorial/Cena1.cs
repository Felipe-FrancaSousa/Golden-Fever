using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cena1 : MonoBehaviour
{
    public float velocidade;
    public GameObject Professor;
    public GameObject Player;
    public GameObject Arma;
    public GameObject JournalCanvas;
    public GameObject PauseCanvas;
    public GameObject hudUI;

    public TextMeshProUGUI dialogo;
    public GameObject painelDialogo;

    public TextMeshProUGUI dialogoCima;
    public GameObject painelDialogoCima;

    public TextMeshProUGUI eCima;
    public TextMeshProUGUI eBaixo;

    public TextMeshProUGUI instrucao;
    public GameObject painelInstrucao;

    public GameObject mapa;
    public GameObject Diario;

    public bool chegou1;
    public bool fim;

    public float delayTexto = 0.025f;

    private Animator animacao;
    private Animator animacaoP;

    private string e = "Aperte E";

    private string[] cena1 =
    {
        "Ah, aí está você!",
        "Procurei-te por toda parte!",
        "Eu adoraria fazer-lhe uma proposta:",
        "Surgiu uma oportunidade de trabalho que eu imagino que\n possa te interessar...",
        "Conhece a lenda da Cidade Perdida de Eldorado?",
        "A lenda de uma cidade inca lendária feita completamente de ouro, você certamente deve se lembrar.",
        "Pela primeira vez na história, achamos indícios que ela pode ter realmente existido!\nVeja isto!"
    };

    private string[] cena2 =
    {
        "Este mapa foi encontrado na minha última expedição para a Amazônia.",
        "Não sabemos sua origem exata, entretanto, ele aparenta possuir três possíveis localizações da cidade perdida.",
        "Para sua missão, você será mandado a cada uma delas e verificará a existência da cidade."
    };

    private string[] cena3 =
    {
        "Como o profissional que você é, você deve catalogar tudo que achar.",
        "Logo, você precisará disso.\nVenha até aqui e pegue isto.",
        "Use as teclas W, A, S e D para caminhar até mim."
    };

    private string[] cena4parte1 =
    {
        "Esse diário de exploração é especial, ele te ajudará a organizar e ler as informações que você obter.",
        "Você pode achar pouco, mas esse é o último modelo em artigos de registro de informação, uma verdadeira obra-prima!",
        "É uma pena ter que dá-lo para você...\nTome, você pode apertar J para acessá-lo."
    };

    private string[] cena4parte2 =
    {
        "Todos os artefatos encontrados serão exibidos na grade à esquerda,",
        "Selecionando um deles, é possível inserir dados como o nome, descrição e ilustração aproximada do item!\nNão é demais?!",
        "Essas informações ajudarão não só você a manter seus achados organizados, como ao museu.",
        "Há muito tempo, nada desse calibre surge, podemos ter uma descoberta verdadeiramente importante nas nossas mãos!",
        "Algo grandioso como isso aumentaria consideravelmente a reputação de nosso museu.",
        "Será também um importante passo para a comunidade histórica...",
        "Conto com seu empenho máximo para essa missão."
    };

    private string[] cena5 =
    {
        "Ah, algo menos importante que você precisa saber é que...",
        "É provável que um grupo contrabandistas tenham tido acesso a informação do nosso achado...",
        "Dessa forma, eles podem ir até os pontos do mapa fortemente armados...",
        "Os artefatos inestimáveis que ruínas antigas podem conter e a cidade de ouro são os alvos deles e...",
        "Já que você estará atrás disso também, eles podem ser hostis com você.",
        "Mas afinal, nós somos homens comprometidos com o conhecimento!",
        "Meros ladrões baratos extremamente armados nunca abalariam nossa determinação!",
        "Por via das dúvidas, leve isto com você."
    };

    private string[] cena6 =
    {
        "Essa arma é uma velha companheira, usei-a em várias das missões da minha época.",
        "Ela dispara apenas seis balas por pente, portanto, não desperdice.",
        "Você pode atirar clicando com o Botão Esquerdo do \nmouse",
        "O que você está fazendo?!\n Não tente atirar aqui! Estamos num local de estudo!",
        "Essa foi por pouco...",
        "Caso precise recarregar, basta apertar R e \naguardar um pouco."
    };

    private string[] cena7 =
    {
        "Você possui tudo que vai precisar carregar.",
        "Comida, água e roupas limpas serão entregues para você regularmente\ne você será transportado por helicóptero.",
        "Eu discutirei outros detalhes com você por telefone, se necessário.",
        "Boa sorte, caro colega!"
    };

    Vector2 posicaoFinal = new Vector2(-6.0f, 0.8f); // Em frente ao player
    Vector2 posicaoFinal2 = new Vector2(-6.0f, 0.4f); // Primeira virada
    Vector2 posicaoFinal3 = new Vector2(3.5f, 0.4f); // Segunda virada
    Vector2 posicaoFinal4 = new Vector2(3.5f, -2.6f); // Em frente a mesa
    Vector2 posicaoFinal5 = new Vector2(3.5f, 0.8f); // Primeira virada
    Vector2 posicaoFinal6 = new Vector2(7.6f, 0.8f); // Em frente a porta
    Vector2 posicaoFinal7 = new Vector2(9.5f, 0.8f); // Fora do mapa

    Vector2 posicaoPlayer = new Vector2(-7, 0.8f);
    Vector2 posicaoPlayer2 = new Vector2(2.5f, -2.6f);
    
    void Start()
    {
        animacao = Professor.GetComponent<Animator>();
        animacaoP = Player.GetComponent<Animator>();

        animacaoP.Play("PlayerIdleUp");

        eCima.text = "";
        eBaixo.text = "";

        Player.GetComponent<PlayerControl>().andarBloqueado = true;
        Player.GetComponent<PlayerControl>().rolamentoBloqueado = true;
        JournalCanvas.GetComponent<JournalScript>().DiarioBloqueado = true;
        PauseCanvas.GetComponent<PauseMenu>().hudBloqueado = true;

        painelDialogo.SetActive(false);
        painelDialogoCima.SetActive(false);
        painelInstrucao.SetActive(false);

        Arma.SetActive(false);
        mapa.SetActive(false);

        StartCoroutine(scriptCena1());
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Cena 1

    IEnumerator scriptCena1()
    {
        // Caminha até a primeira parada, na estante

        yield return new WaitForSeconds(7);
        animacao.Play("AndarEsquerda");
        while (Vector2.Distance(posicaoFinal, Professor.transform.position) > 0)
        {
            Professor.transform.position = Vector2.MoveTowards(Professor.transform.position, posicaoFinal, velocidade * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        animacao.StopPlayback();
        animacao.Play("Respirar");

        // Player anda até ele

        animacaoP.Play("PlayerMoveDown");

        while (Vector2.Distance(posicaoPlayer, Player.transform.position) > 0)
        {
            Player.transform.position = Vector2.MoveTowards(Player.transform.position, posicaoPlayer, velocidade * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        animacaoP.Play("PlayerIdleRight");

        yield return new WaitForSeconds(0.5f);

        // Fala do Peru

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

        eBaixo.text = "";
        painelDialogo.SetActive(false);

        // Entrega o mapa

        animacao.Play("EntregarItem");
        yield return new WaitForSeconds(0.5f);

        for (int j = 0; j <= "É um mapa, tome".Length; j++)
        {
            dialogo.text = "É um mapa, tome".Substring(0, j);
            yield return new WaitForSeconds(delayTexto);
        }

        for (int j = 0; j <= e.Length; j++)
        {
            eBaixo.text = e.Substring(0, j);
            yield return new WaitForSeconds(delayTexto);
        }

        painelDialogo.SetActive(true);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        yield return new WaitForEndOfFrame();

        painelDialogo.SetActive(false);
        painelInstrucao.SetActive(true);

        instrucao.text = "Aperte <b>E</b> para pegar o mapa";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        yield return new WaitForEndOfFrame();

        StartCoroutine(scriptCena2());
    }

    IEnumerator scriptCena2()
    {

        painelInstrucao.SetActive(false);
        animacao.StopPlayback();
        animacao.Play("GuardarItem");

        yield return new WaitForSeconds(1);

        animacao.StopPlayback();
        animacao.Play("Respirar");

        mapa.SetActive(true);

        yield return new WaitForSeconds(1);

        // Fala do mapa

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
        instrucao.text = "Aperte <b>E</b> para fechar o mapa";
        painelInstrucao.SetActive(true);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        yield return new WaitForEndOfFrame();

        StartCoroutine(scriptCena3());
    }

    IEnumerator scriptCena3()
    {
        mapa.SetActive(false);

        painelInstrucao.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        // Caminha até  a mesa

        yield return new WaitForSeconds(0.3f);
        animacao.Play("AndarBaixo");
        while (Vector2.Distance(posicaoFinal2, Professor.transform.position) > 0)
        {
            Professor.transform.position = Vector2.MoveTowards(Professor.transform.position, posicaoFinal2, velocidade * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        animacao.StopPlayback();

        animacao.Play("AndarDireita");
        while (Vector2.Distance(posicaoFinal3, Professor.transform.position) > 0)
        {
            Professor.transform.position = Vector2.MoveTowards(Professor.transform.position, posicaoFinal3, velocidade * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        animacao.StopPlayback();
        animacao.Play("AndarBaixo");
        
        while (Vector2.Distance(posicaoFinal4, Professor.transform.position) > 0)
        {
            Professor.transform.position = Vector2.MoveTowards(Professor.transform.position, posicaoFinal4, velocidade * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        animacao.StopPlayback();
        animacao.Play("Respirar");

        yield return new WaitForSeconds(1);
        painelDialogoCima.SetActive(true);

        eCima.text = "";
        painelDialogoCima.SetActive(true);

        // Fala pra andar

        for (int i = 0; i < cena3.Length; i++)
        {
            for (int j = 0; j <= cena3[i].Length; j++)
            {
                dialogoCima.text = cena3[i].Substring(0, j);
                yield return new WaitForSeconds(delayTexto);
            }

            for (int j = 0; j <= e.Length; j++)
            {
                eCima.text = e.Substring(0, j);
                yield return new WaitForSeconds(delayTexto);
            }

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            yield return new WaitForEndOfFrame();

            eCima.text = "";
        }

        painelDialogoCima.SetActive(false);

        painelInstrucao.SetActive(true);
        instrucao.text = "Use <b>W</b>, <b>A</b>, <b>S</b> e <b>D</b> para caminhar até a mesa";

        Player.GetComponent<PlayerControl>().andarBloqueado = false;

        animacaoP.Play("Idle Animation");

        yield return new WaitUntil(() => chegou1);

        StartCoroutine(scriptCena4());
    }

    IEnumerator scriptCena4()
    {
        painelInstrucao.SetActive(false);
        Player.GetComponent<PlayerControl>().andarBloqueado = true;
        Player.GetComponent<PlayerControl>().moveSpeed = 0;
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        // Move o player até a posição correta

        animacaoP.Play("Idle Animation");

        while (Vector2.Distance(posicaoPlayer2, Player.transform.position) > 0)
        {
            Player.transform.position = Vector2.MoveTowards(Player.transform.position, posicaoPlayer2, velocidade * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        Player.transform.position = posicaoPlayer2;

        animacaoP.Play("PlayerIdleRight");

        // Fala do diário

        eCima.text = "";
        painelDialogoCima.SetActive(true);

        for (int i = 0; i < cena4parte1.Length; i++)
        {
            for (int j = 0; j <= cena4parte1[i].Length; j++)
            {
                dialogoCima.text = cena4parte1[i].Substring(0, j);
                yield return new WaitForSeconds(delayTexto);
            }

            for (int j = 0; j <= e.Length; j++)
            {
                eCima.text = e.Substring(0, j);
                yield return new WaitForSeconds(delayTexto);
            }

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            yield return new WaitForEndOfFrame();

            eCima.text = "";
        }

        painelDialogoCima.SetActive(false);
        painelInstrucao.SetActive(true);
        JournalCanvas.GetComponent<JournalScript>().DiarioBloqueado = false;
        hudUI.SetActive(false);
        Diario.SetActive(false);
        instrucao.text = "Aperte <b>J</b> para abrir o diário";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.J));

        if(JournalScript.estaNoJournal == true)
        {
            Time.timeScale = 1f;
            JournalCanvas.GetComponent<JournalScript>().DiarioBloqueado = true;
        }

        painelInstrucao.SetActive(false);

        yield return new WaitForSeconds(1);

        eBaixo.text = "";
        painelDialogo.SetActive(true);

        for (int i = 0; i < cena4parte2.Length; i++)
        {
            for (int j = 0; j <= cena4parte2[i].Length; j++)
            {
                dialogo.text = cena4parte2[i].Substring(0, j);
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
        painelInstrucao.SetActive(true);

        instrucao.text = "Aperte <b>J</b> para fechar o diário";

        JournalCanvas.GetComponent<JournalScript>().DiarioBloqueado = false;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.J));

        JournalCanvas.GetComponent<JournalScript>().DiarioBloqueado = true;
        hudUI.SetActive(false);

        StartCoroutine(scriptCena5());
    }

    IEnumerator scriptCena5()
    {
        painelInstrucao.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        // Fala dos inimigos

        eCima.text = "";
        painelDialogoCima.SetActive(true);

        for (int i = 0; i < cena5.Length; i++)
        {
            for (int j = 0; j <= cena5[i].Length; j++)
            {
                dialogoCima.text = cena5[i].Substring(0, j);
                yield return new WaitForSeconds(delayTexto);
            }

            for (int j = 0; j <= e.Length; j++)
            {
                eCima.text = e.Substring(0, j);
                yield return new WaitForSeconds(delayTexto);
            }

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            yield return new WaitForEndOfFrame();

            eCima.text = "";
        }

        painelDialogoCima.SetActive(false);

        animacao.Play("EntregarItem");

        yield return new WaitForSeconds(1);

        painelInstrucao.SetActive(true);
        instrucao.text = "Aperte <b>E</b> para pegar o objeto";

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));

        painelInstrucao.SetActive(false);

        animacao.Play("GuardarItem");
        yield return new WaitForSeconds(1);

        animacao.Play("Respirar");


        StartCoroutine(scriptCena6());
    }

    IEnumerator scriptCena6()
    {
        Arma.SetActive(true);

        eCima.text = "";
        painelDialogoCima.SetActive(true);

        // Fala da arma

        for (int i = 0; i < cena6.Length; i++)
        {
            for (int j = 0; j <= cena6[i].Length; j++)
            {
                dialogoCima.text = cena6[i].Substring(0, j);
                yield return new WaitForSeconds(delayTexto);
            }

            for (int j = 0; j <= e.Length; j++)
            {
                eCima.text = e.Substring(0, j);
                yield return new WaitForSeconds(delayTexto);
            }

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            yield return new WaitForEndOfFrame();

            eCima.text = "";
        }

        painelDialogoCima.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        Arma.SetActive(false);

        // Vai até a porta

        animacao.Play("AndarCima");
        while (Vector2.Distance(posicaoFinal5, Professor.transform.position) > 0)
        {
            Professor.transform.position = Vector2.MoveTowards(Professor.transform.position, posicaoFinal5, velocidade * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        animacao.StopPlayback();
        animacao.Play("AndarDireita");
        
        while (Vector2.Distance(posicaoFinal6, Professor.transform.position) > 0)
        {
            Professor.transform.position = Vector2.MoveTowards(Professor.transform.position, posicaoFinal6, velocidade * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        animacao.StopPlayback();
        animacao.Play("Respirar");

        animacaoP.StopPlayback();
        animacaoP.Play("PlayerIdleUpRight");

        yield return new WaitForSeconds(0.5f);

        eCima.text = "";
        painelDialogoCima.SetActive(true);

        // Dá adeus

        for (int i = 0; i < cena7.Length; i++)
        {
            for (int j = 0; j <= cena7[i].Length; j++)
            {
                dialogoCima.text = cena7[i].Substring(0, j);
                yield return new WaitForSeconds(delayTexto);
            }

            for (int j = 0; j <= e.Length; j++)
            {
                eCima.text = e.Substring(0, j);
                yield return new WaitForSeconds(delayTexto);
            }

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            yield return new WaitForEndOfFrame();

            eCima.text = "";
        }

        painelDialogoCima.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        // Sai

        animacao.Play("AndarDireita");
        
        while (Vector2.Distance(posicaoFinal7, Professor.transform.position) > 0)
        {
            Professor.transform.position = Vector2.MoveTowards(Professor.transform.position, posicaoFinal7, velocidade * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        animacao.StopPlayback();

        painelInstrucao.SetActive(false);

        // Acaba

        GetComponent<FadeOut>().fim = true;
    }

    public void PularTutorial()
    {
        GetComponent<FadeOut>().fim = true;
    }
}
