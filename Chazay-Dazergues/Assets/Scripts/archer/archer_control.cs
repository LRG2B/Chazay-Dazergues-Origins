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

    private void Start()
    {
        anim = GetComponent<Animator>();
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
        if (player_ray.collider != null)
        {
            // 30% chance envoyer flèche
            if(10 == Random.Range(10,400))
            {
                StartCoroutine(Attack());
            }
        }
        //sinon rien

    }



    IEnumerator Attack()
    {
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(0.4f);
        Instantiate(projectilePrefab, LaunchOffset.position, transform.rotation);
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
