using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    Health playerScript;
    public int QuantidadeCura;


    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"  )
        {
            playerScript.Cura(QuantidadeCura);
            Destroy(gameObject);

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
