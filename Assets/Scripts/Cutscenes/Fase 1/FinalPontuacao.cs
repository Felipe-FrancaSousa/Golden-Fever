using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPontuacao : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas;
    private void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.layer
            == LayerMask.NameToLayer("Player"))
        {
            Debug.Log(Pontuacao.pontosAtuais);
            GetComponent<InserirPontuacao>().insere = true;
            canvas.GetComponent<cena>().chegouFinal = true;
        }
    }
}
