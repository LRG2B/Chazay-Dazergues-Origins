using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class coin_pickable : MonoBehaviour
{

    public int value = 1;
    bool destroy = false;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !destroy)
        {
            destroy = true;
            Inventory.instance.AddCoins(value);
            Destroy(gameObject);
        }
    }
}