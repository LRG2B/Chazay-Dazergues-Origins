using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public int domage;
    public float speed = 4.5f;

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject.transform.root.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Health.instance.TakeDamage(domage);
        }
        Destroy(gameObject.transform.root.gameObject);
    }
}
