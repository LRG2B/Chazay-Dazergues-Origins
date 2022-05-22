using UnityEngine;

public class potion_pickable : MonoBehaviour
{
    bool destroy = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !destroy)
        {
            destroy = true;
            Inventory.instance.AddPotions();
            Destroy(gameObject);
        }
    }
}