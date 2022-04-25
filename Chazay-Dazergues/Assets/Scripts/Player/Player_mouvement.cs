using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_mouvement : MonoBehaviour
{

    Rigidbody2D playerRB;
    SpriteRenderer playerRender;
    Animator playerAnim;
    bool canMove = true;
    bool facingRight = true;
    public float Speed;

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
}
