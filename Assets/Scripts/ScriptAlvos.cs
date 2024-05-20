using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAlvos : MonoBehaviour
{
    public string ID;
    public bool EstaAtivado = false;
    public Sprite sprite;
    public Sprite spriteOriginal;
    public GameObject Puzzle;
    public BoxCollider2D Caixa;
    AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.tag == "Bala")
        {

            if (!EstaAtivado)
            {
                GetComponent<SpriteRenderer>().sprite = sprite;
                Caixa.enabled = false;
                Puzzle.GetComponent<ScriptPuzzleAlvos>().Acertos += ID;
                EstaAtivado = true;
                Audio.Play();
            }

        }
    }

    public void SequenciaErrada()
    {
        GetComponent<SpriteRenderer>().sprite = spriteOriginal;
        Caixa.enabled = true;
        EstaAtivado = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
