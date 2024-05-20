using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFrango : MonoBehaviour
{
    Animator anim;
    public float TempoDeVida;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Sumir");
        anim = GetComponent<Animator>();
    }

    IEnumerator Sumir()
    {
        yield return new WaitForSeconds(TempoDeVida);
        anim.Play("FrangoSumindo");
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
