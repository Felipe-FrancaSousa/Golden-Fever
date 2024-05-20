using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AtivarSlot : MonoBehaviour
{

    public Toggle slot;
    public Image Mostrador;
    public Image Sprite;
    public Itens item;

    [HideInInspector]

    public TextMeshProUGUI Titulo;
    public TextMeshProUGUI  Descricao;
    
    Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        JournalScript.GuardaSlot[0] = true;
    }

    void Start()
    {
        anim = Mostrador.GetComponent<Animator>();
        Mostrador.enabled = false;
    }

    private void selecao()
    {
        if (slot.isOn)
        {
            Mostrador.enabled = true;
            Titulo.text = item.NomeItem;
            Descricao.text = item.DescricaoItem;
            Mostrador.sprite = Sprite.sprite;
            anim.Play(item.NomeAnimacao);
        }
        else
        {
            return;
        }
    }
    void SalvarSlot()
    {
        if (slot.interactable == true)
        {
            for (int i = 1; i < JournalScript.GuardaSlot.Length; i++)
            {
                if (item.IdSlot == i)
                {
                    JournalScript.GuardaSlot[i] = true;
                }
            }
        }
        else
        {
            return;
        }
    }
    void VerificaSlot()
    {
        if (JournalScript.GuardaSlot[item.IdSlot] == true)
        {
            slot.interactable = true;
        }
        else
        {
            slot.interactable = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        selecao();
        SalvarSlot();
        VerificaSlot();
    }
}
