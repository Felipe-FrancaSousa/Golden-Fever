using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBau : MonoBehaviour
{
    public float velocidade = 2.0f;
    public bool EstaAberto = false;
    public bool soltarItem = false;
    public GameObject Item;
    Animator anima;
    public Transform ponto1;
    public Transform ponto2;

    private void Awake()
    {
        EstaAberto = false;
    }

    void Start()
    {
        anima = GetComponent<Animator>();
        anima.enabled = false;
        Item.GetComponent<BoxCollider2D>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
          if(!EstaAberto)
            {
                anima.enabled = true;
                EstaAberto = true;
            }
        }

    }

    public void parar()
    {
        anima.enabled = false;
        Item.SetActive(true);
        soltarItem = true;
        StartCoroutine("MoveItem");
    }

    
    IEnumerator MoveItem()
    {
        if(soltarItem)
        {
            yield return new WaitForSeconds(0);
            while(Vector2.Distance(Item.transform.position, ponto1.position) > 0)
            {
                Item.transform.position = Vector2.MoveTowards(Item.transform.position, ponto1.position, velocidade * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            while (Vector2.Distance(Item.transform.position, ponto2.position) > 0)
            {
                Item.transform.position = Vector2.MoveTowards(Item.transform.position, ponto2.position, velocidade * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForSeconds(0.2f);
            Item.GetComponent<BoxCollider2D>().enabled = true;
            soltarItem = false;
        }


    }

}
