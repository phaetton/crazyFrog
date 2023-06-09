using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

public float runSpeed=2;
public float jumpSpeed=3;
Rigidbody2D rb2D;

public bool betterJump = false;
public float fallJumMultiplier = 0.5f;
public float lowJumpMultiplier = 1f;

    //arrastra el sprite renderer en el campo nuevo en la vista
    public SpriteRenderer spriteRenderer;

    public Animator animator;

    void Start()
    {
        //generando conexión sin la vista
        rb2D=GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(Input.GetKey("d") || Input.GetKey("right")) {
            //camina a la derecha
            rb2D.velocity = new Vector2(runSpeed, rb2D.velocity.y);
            //gira a la derecha
            spriteRenderer.flipX = false;
            //animación correr
            animator.SetBool("Run", true);
        }
        else if(Input.GetKey("a") || Input.GetKey("left")) {
            //camina a la izquierda
            rb2D.velocity = new Vector2(-runSpeed, rb2D.velocity.y);
            //gira a la izquierda
            spriteRenderer.flipX = true;
            //animación correr
            animator.SetBool("Run", true);
        }
        else{
            //no tecla presionada
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            //sin animación correr
            animator.SetBool("Run", false);
        }

        if((Input.GetKeyUp("w") || Input.GetKeyUp("space") || Input.GetKeyUp("up")) ) {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            animator.SetBool("Jump", true);
        }

        //esta en el suelo
        if(checkGround.isGrounded == true) {
            animator.SetBool("Jump", false);
        } 
        if (checkGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);

        }

        if (betterJump){
            if(rb2D.velocity.y<0){
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallJumMultiplier) * Time.deltaTime;
                animator.SetBool("Jump", true);
            }
            if(rb2D.velocity.y>0 && !(Input.GetKeyUp("w") || Input.GetKeyUp("space") || Input.GetKeyUp("up")))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
                animator.SetBool("Jump", true);
                animator.SetBool("Run", false);
            }
        }
    }
}
