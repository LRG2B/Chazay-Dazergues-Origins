using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    //conponent player
    Rigidbody2D playerRB;
    SpriteRenderer playerRender;
    Animator playerAnim;

    //mouvement player
    bool canMove = true;
    bool facingRight = true;
    public float Speed;

    //jump player
    bool is_grounded = true;
    public float jump_power = 1.0f;
    public LayerMask Ground;
    float groundCheckRadius = 0.2f;
    public Transform ground_check;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerRender = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }

    
    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        if (canMove)
        {
            playerRB.velocity = new Vector2(move * Speed, playerRB.velocity.y);
            // la ligne en dessous serviras pour l'animation
            playerAnim.SetFloat("horizontal_speed", Mathf.Abs(move)); // Defini une valeur pour le float MoveSpeed dans notre animator
        }
        else
        {
            playerRB.velocity = new Vector2(0, playerRB.velocity.y); // Si movement non autorise, on arrete la velocite
            // la ligne en dessous serviras pour l'animation
            playerAnim.SetFloat("horizontal_speed", 0); // on arrete aussi l'animation en cours si on etait en train de courir
        }

        Jump(); // fonction jump

        //Flip
        if (move < 0 && facingRight == true)
        {
            Flip();
        }
        else if (move > 0 && facingRight == false)
            Flip();
    }



    void Flip()
    {
        
         facingRight = !facingRight;
         // On change la valeur du boolen facing right par son contraire, representant la direction du personnage
         playerRender.flipX = !playerRender.flipX;
         // Même chose ici pour que notre flipx et facingRight soient en phase
    }

    void Jump()
    {
        if (is_grounded && Input.GetAxis("Jump") > 0)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, 0f); // On d�fini la velocite y a 0 pour etre sur d'avoir la m�me hauteur quelque soit le contexte
            playerRB.AddForce(new Vector2(0, jump_power), ForceMode2D.Impulse); //le saut 
            is_grounded = false; // et on change la valeur du booleen
        }
        is_grounded = Physics2D.OverlapCircle(ground_check.position, groundCheckRadius, Ground); //On regarde si on touche le sol et on change le booleen en concequant        
    }
}
