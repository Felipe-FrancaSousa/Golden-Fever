using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AvisoColeta : MonoBehaviour
{

    public TextMeshProUGUI avisoTxt;
    // Start is called before the first frame update
    void Awake()
    {
        avisoTxt.enabled = false;
    }
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coletavel")
        {
            avisoTxt.text = "Nova Entrada no diario, aperte <b>J</b> para saber mais!";
            avisoTxt.enabled = true;
            avisoTxt.CrossFadeAlpha(0, 0, false);
            StartCoroutine("Aviso");
        }
    }
    
    IEnumerator Aviso()
    {
        yield return new WaitForSeconds(0);
        avisoTxt.CrossFadeAlpha(1, 1, false);
        yield return new WaitForSeconds(2);
        avisoTxt.CrossFadeAlpha(0, 2, false);
        yield return new WaitForSeconds(2);
        avisoTxt.enabled = false;
    }
}
