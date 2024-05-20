using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //Variaveis 
    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalModifier;
    public float rollIncrease;
    public float timeAfterRoll;

    private Animator anim;
    private Rigidbody2D CharacterRigidbody;
    private ParticleSystem poeira;

    public bool playerMoving;
    public static bool rolling;
    private bool pressedSpace;
    private Vector2 lastMove;

    private float timeTemp = 0f;

    private float movX;
    private float movY;
    private Vector2 lastMoveRoll;

    private bool estaPausado;

    public bool andarBloqueado;
    public bool rolamentoBloqueado;

    //public GameObject ponteiro;



    // Inicialização
    void Start()
    {
        anim = GetComponent<Animator>();
        CharacterRigidbody = GetComponent<Rigidbody2D>();
        poeira = GetComponent<ParticleSystem>();
    }

    // Update é chamado uma vez a cada frame
    void Update()
    {
        if (ControladorDeFase.estaMorto)
        {
            return;
        }
        var em = poeira.emission;

        //Movimentação Basica do Player
        playerMoving = false;
        
        estaPausado = PauseMenu.EstaPausado;
        if (estaPausado)
        {
            em.enabled = false;
            return;
        }

        if (andarBloqueado)
        {
            em.enabled = false;
            return;
        }

        if (rolling == false)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                CharacterRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, CharacterRigidbody.velocity.y);
                playerMoving = true;
                em.enabled = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                CharacterRigidbody.velocity = new Vector2(CharacterRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                playerMoving = true;
                em.enabled = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));

            }

            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            {
                em.enabled = true;
                CharacterRigidbody.velocity = new Vector2(0f, CharacterRigidbody.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                em.enabled = true;
                CharacterRigidbody.velocity = new Vector2(CharacterRigidbody.velocity.x, 0f);
            }

            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
            anim.SetBool("Rolling", false);

        }

        if (Input.GetAxisRaw("Roll") > 0.5f && playerMoving == true && !rolamentoBloqueado)
        {
            movX = Input.GetAxisRaw("Horizontal");
            movY = Input.GetAxisRaw("Vertical");
            lastMoveRoll = lastMove;
            rolling = true;
        }

        if (rolling == true)
        {
            timeTemp += Time.deltaTime;
            if (timeTemp < 0.5f)
            {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
                {
                    currentMoveSpeed = moveSpeed * diagonalModifier * rollIncrease;
                    CharacterRigidbody.velocity = new Vector2(movX * currentMoveSpeed, movY * currentMoveSpeed);
                }
                else
                {
                    currentMoveSpeed = moveSpeed * rollIncrease;
                    CharacterRigidbody.velocity = new Vector2(movX * currentMoveSpeed, movY * currentMoveSpeed);
                }
                anim.SetBool("Rolling", true);
            }
            else
            {
                anim.SetBool("Rolling", false);
                rolling = false;
            }
            anim.SetFloat("MoveX", movX);
            anim.SetFloat("MoveY", movY);
            anim.SetFloat("LastMoveX", lastMoveRoll.x);
            anim.SetFloat("LastMoveY", lastMoveRoll.y);


        }

        if (timeTemp > 0.5f)
        {
            timeTemp += Time.deltaTime;
            if (timeTemp > timeAfterRoll)
            {
                timeTemp = 0;
            }

        }

        //Correção da Diagonal

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
        {

            currentMoveSpeed = moveSpeed * diagonalModifier;

        }
        else
        {
            currentMoveSpeed = moveSpeed;
        }

        if (!playerMoving)
        {
            em.enabled = false;
        }

        //Animação
        anim.SetBool("PlayerMoving", playerMoving);
    }
}