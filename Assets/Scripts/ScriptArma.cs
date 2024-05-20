using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScriptArma : MonoBehaviour
{
    public bool estaAtirando;

    public float offset;

    public GameObject prefabBala;

    public Transform firepoint;

    public int municaoTotal;

    public int municaoAtual;

    public int tempoDeRecarga;

    private bool estaRecarregando = false;

    public Image[] balas;

    public Sprite balaCheia;

    public Sprite balaVazia;

    private bool estaRolando;

    private bool estaPausado;

    private bool estaNoJournal;

    private bool esperaDisparo = false;

    public float tempoDeEspera;

    Animator cameraAnimator;

    private bool estaMorto;

    public AudioSource AudioTiro;
    public AudioSource AudioRecarga;
    void Start ()
    {
        cameraAnimator = Camera.main.GetComponent<Animator>();
        municaoAtual = municaoTotal;
        esperaDisparo = true;
    }
    private void Update()
    {
        estaPausado = PauseMenu.EstaPausado;
        estaNoJournal = JournalScript.estaNoJournal;
        estaMorto = ControladorDeFase.estaMorto;

        if (estaPausado || estaNoJournal || estaMorto)
        {
            return;
        }

        Vector3 diferenca = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotacaoZ = Mathf.Atan2(diferenca.y, diferenca.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotacaoZ + offset);

        estaRolando = PlayerControl.rolling;

        if (estaRecarregando || estaRolando)
        {
            return;
        }

        if (Input.GetButtonDown("Reload"))
        {
            if(municaoAtual != municaoTotal)
            {
                StartCoroutine(Recarrega());
            }
        
            return;
        }

        if (municaoAtual <= 0)
        {
            if (Input.GetButtonDown("Reload") || Input.GetButtonDown("Fire1"))
            {
            StartCoroutine(Recarrega());
            
            }
            return;
            
        }


        if (Input.GetButtonDown("Fire1") && esperaDisparo == true)
        {
            Atira();
            esperaDisparo = false;
            StartCoroutine("TempoDeTiro");
        }

          for (int i = 0; i < balas.Length; i++){
            if(i < municaoAtual)
                {
                balas[i].sprite = balaCheia;
            } else {
                balas[i].sprite = balaVazia;
            }

            if(i < municaoTotal){
                balas[i].enabled = true;
            } else {
                balas[i].enabled = false;
            }
        }
            
    }

    IEnumerator TempoDeTiro()
    {
        yield return new WaitForSeconds(tempoDeEspera);
        esperaDisparo = true;
    }
    IEnumerator Recarrega()
    {
        estaRecarregando = true;
        AudioRecarga.Play();
        yield return new WaitForSeconds(tempoDeRecarga);
        municaoAtual = municaoTotal;
        estaRecarregando = false;
    }
    void Atira ()
    {
        AudioTiro.Play();
        cameraAnimator.SetTrigger("cameraScreenshake");
        Instantiate(prefabBala, firepoint.position, transform.rotation);
        municaoAtual--;
    }
}
