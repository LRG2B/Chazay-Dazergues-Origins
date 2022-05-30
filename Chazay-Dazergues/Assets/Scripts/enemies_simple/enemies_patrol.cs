using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies_patrol : MonoBehaviour
{
    public static enemies_patrol instance;   //def static pour gerer les PV dans d'autre scripts

    public float speed;
    public Transform[] waypoints;
    public int domage;
    public int PV_max = 100;
    public int PV = 100;

    SpriteRenderer sprite;
    Animator anim;
    Transform target;
    int dest_point;


    void Start()
    {
        target = waypoints[0];
        anim = GetComponent<Animator>();
        instance = this;
        sprite = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //si  il est arriver a moin de 0.3f de la destination il repart sur sont autre point de destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            dest_point = (dest_point + 1) % waypoints.Length;
            target = waypoints[dest_point];
            //retourne le personnage
            sprite.flipX = !sprite.flipX;
        }
    }
}
