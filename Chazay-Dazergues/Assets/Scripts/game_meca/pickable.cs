using UnityEngine;

public class pickable : MonoBehaviour
{

    public int value = 1;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inventory.instance.AddCoins(value);
            Destroy(gameObject.transform.root.gameObject);
        }
    }
}