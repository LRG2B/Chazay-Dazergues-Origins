using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_mouv : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;
    Transform target;
    int dest_point;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints[0];
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
        }
    }

}
