using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform attack_point;
    public float attack_range = 0.5f;
    public LayerMask enemy_layer;
    public int attack_domage = 50;
    Animator anim;
    string[] attack_anim  = new string[] { "attack0", "attack1", "attack2" };
    int attack_num;
    bool can_attack = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        attack_num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (can_attack && !anim.GetBool("dead") )
        {
            if (Input.GetButtonDown("Fire1") || Input.GetMouseButtonDown(0)) // si le clic gauche est presser
            {
                can_attack = false;
                StartCoroutine(Wait());
                anim.SetTrigger(attack_anim[attack_num]);
                attack(); // attaque 
            }
            attack_num = (attack_num + 1) % attack_anim.Length;
        }
    }


    void attack()
    {
        // detecte les enemies a porté
        Collider2D[] hit_enemies_l = Physics2D.OverlapCircleAll(attack_point.position, attack_range, enemy_layer);
        // et les attaque tous 
        foreach (Collider2D enemy in hit_enemies_l)
        {
            Debug.Log("Player attaque : " + enemy.tag);

            if (enemy.CompareTag("enemy_simple"))  // test si l'enemy est de type enemy 1
            {
                enemy.GetComponent<enemies_patrol>().Take_domage(attack_domage);
            }
            
        }

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        can_attack = true;
    }

    public void UpgradeDamage(int damage)
    {
        attack_domage += damage;
    }
}