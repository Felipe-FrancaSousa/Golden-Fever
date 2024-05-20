using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;


    // Use this for initialization
    void Awake()
    {
        moverAoPlayer(gameObject);
    }

    // Update is called once per frame
    void Update () {
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        
	}
    public void moverAoPlayer(GameObject camera)
    {
        Vector3 posicaoInicial = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, gameObject.transform.position.z);
        camera.transform.position = posicaoInicial;

    }

}
