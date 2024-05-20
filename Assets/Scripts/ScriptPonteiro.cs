using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPonteiro : MonoBehaviour
{
    public GameObject ponteiroMira;

    [HideInInspector]

    public Transform player;
    void Start()
    {
        Cursor.visible = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector2.Distance(Input.mousePosition, player.position) < 3)
        {
            ponteiroMira.SetActive(false);
        }
        ponteiroMira.transform.position = Input.mousePosition;
        
    }
}
