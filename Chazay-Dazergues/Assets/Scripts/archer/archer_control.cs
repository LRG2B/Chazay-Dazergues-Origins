using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archer_control : MonoBehaviour
{
    public arrow projectilePrefab;
    public Transform LaunchOffset;
    Animator anim;
    RaycastHit2D player_ray;

    public int PV_max = 100;
    public int PV = 100;
    public bool canAttack;

    private void Start()
    {
        anim = GetComponent<Animator>();
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(Attack());
        }

        // envoie raycast
        player_ray = Physics2D.Raycast(transform.position, Vector2.left);

        //test si quelque chose toucher
        if (player_ray.collider != null && canAttack)
        {
            // 30% chance envoyer flèche
            canAttack = false;
            if(5 == Random.Range(1,400))
            {
                StartCoroutine(Attack());
            }
            else
            {
                canAttack = true;
            }
        }
        //sinon rien

    }


    IEnumerator Attack()
    {
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(0.4f);
        Instantiate(projectilePrefab, LaunchOffset.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        canAttack = true;
    }

    public void Take_domage(int domage)
    {
        PV -= domage;
        anim.SetTrigger("hit");
        if (PV < 0)
        {
            Destroy(gameObject.transform.root.gameObject);
        }
    }

}
