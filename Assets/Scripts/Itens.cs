using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Itens
{
    public string NomeItem;
    public string DescricaoItem;
    public string NomeAnimacao;
    public int IdSlot;

    public Itens(int ID, string nome, string descricao, string animacao)
    {
        IdSlot = ID;
        NomeItem = nome;
        DescricaoItem = descricao;
        NomeAnimacao = animacao;
    }
}
