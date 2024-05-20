using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptPuzzleAlvos : MonoBehaviour
{
    public GameObject alvo1;
    public GameObject alvo2;
    public GameObject alvo3;
    public GameObject Passagem;
    public string Acertos = "";
    public AudioSource[] Audios = new AudioSource[2];
    // Start is called before the first frame update
    void Start()
    {

    }

    void Verifica()
    {
        if (Acertos == "123")
        {
            Audios[0].Play();
            Passagem.SetActive(false);
            
        }
        else if (Acertos.Length == 3 && Acertos != "123")
        {
            Audios[1].Play();
            StartCoroutine("Erro");
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        Verifica();
    }

    IEnumerator Erro()
    {
        
        yield return new WaitForSeconds(1);
        alvo1.GetComponent<ScriptAlvos>().SequenciaErrada();
        alvo2.GetComponent<ScriptAlvos>().SequenciaErrada();
        alvo3.GetComponent<ScriptAlvos>().SequenciaErrada();
        Acertos = "";
    }
}
