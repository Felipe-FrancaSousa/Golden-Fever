using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Contador : MonoBehaviour
{
    public TextMeshProUGUI contador;
    public static int MoedasTotais = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoedasTotais = int.Parse(contador.text);

        if (collision.tag == "Moeda")
        {
            if(MoedasTotais < 9)
            {
                contador.text = "0" + (MoedasTotais + 1).ToString();
            }
            else
            {
                contador.text = (MoedasTotais + 1).ToString();
            }
           
        }
    }
}
