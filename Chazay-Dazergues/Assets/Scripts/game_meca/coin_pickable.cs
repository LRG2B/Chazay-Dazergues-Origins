using UnityEngine;

public class coin_pickable : MonoBehaviour
{

    public int value = 1;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddCoins(value);
            Destroy(gameObject.transform.root.gameObject);
        }
    }
}