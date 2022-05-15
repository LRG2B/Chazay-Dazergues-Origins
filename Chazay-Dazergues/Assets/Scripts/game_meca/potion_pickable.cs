using UnityEngine;

public class potion_pickable : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddPotions();
            Destroy(gameObject.transform.root.gameObject);
        }
    }
}