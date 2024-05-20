using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{


    public double vidaAtual;

    private float vidaTotal = 3;

    public Image[] hearts;

    public Sprite coracaoCheio;

    public Sprite coracaoVazio;

    public Sprite coracaoMeio;

    public GameObject player;

    public bool estaRolando;

    public GameObject controladorDeFase;
    //public delegate void meuDelegate();

    //public event meuDelegate AoMorrer;

    void Update(){

        estaRolando = PlayerControl.rolling;

            if(vidaAtual > vidaTotal)
            {
                vidaAtual = vidaTotal;
            }

            if (vidaAtual <= 0)
            {
        
            hearts[0].sprite = coracaoVazio;
            hearts[1].sprite = coracaoVazio;
            hearts[2].sprite = coracaoVazio;
            Morte();

            }else if(vidaAtual == 0.5)
            {
                hearts[0].sprite = coracaoMeio;
                hearts[1].sprite = coracaoVazio;
                hearts[2].sprite = coracaoVazio;
            }else if(vidaAtual == 1)
            {
                hearts[0].sprite = coracaoCheio;
                hearts[1].sprite = coracaoVazio;
                hearts[2].sprite = coracaoVazio;
            }else if(vidaAtual == 1.5)
            {
                hearts[0].sprite = coracaoCheio;
                hearts[1].sprite = coracaoMeio;
                hearts[2].sprite = coracaoVazio;
            }else if(vidaAtual == 2)
            {
                hearts[0].sprite = coracaoCheio;
                hearts[1].sprite = coracaoCheio;
                hearts[2].sprite = coracaoVazio;
            }else if(vidaAtual == 2.5)
            {
                hearts[0].sprite = coracaoCheio;
                hearts[1].sprite = coracaoCheio;
                hearts[2].sprite = coracaoMeio;
            }else if(vidaAtual == 3)
            {
                hearts[0].sprite = coracaoCheio;
                hearts[1].sprite = coracaoCheio;
                hearts[2].sprite = coracaoCheio;
            }

      
    }

    public void Cura(int QuantidadeCura)
    {if(vidaAtual + QuantidadeCura > 3)
        {
            vidaAtual = 3;
        }
        else
        {
            vidaAtual += QuantidadeCura;
        }
      
    }

    public void DanoNoPlayer()
    {
        if (!estaRolando)
        {
            vidaAtual -= 0.5;
        }
        
    }

    public void Morte()
    {
        ControladorDeFase.estaMorto = true;
        controladorDeFase.GetComponent<ControladorDeFase>().aoMorrer();
    }
}
