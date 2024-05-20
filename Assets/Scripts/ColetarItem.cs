using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColetarItem : MonoBehaviour
{
    public Toggle slot;
    public int IdItem;
    int PontosArtefatos = 200;

    void Awake()
    {
        if(JournalScript.GuardaSlot[IdItem] == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            slot.interactable = true;
            Destroy(gameObject);
            Pontuacao.Pontuar(PontosArtefatos);

        }
    }

}
