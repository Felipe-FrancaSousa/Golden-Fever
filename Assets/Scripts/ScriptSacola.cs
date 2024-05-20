using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSacola : MonoBehaviour
{
    public GameObject Moeda;
    Animator anima;
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anima.Play("SacolaAbrindo");   
    }

    void DropMoeda()
    {
        Instantiate(Moeda, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
