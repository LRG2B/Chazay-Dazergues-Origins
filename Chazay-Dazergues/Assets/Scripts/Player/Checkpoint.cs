using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    private Transform playerSpawn;

    // Start is called before the first frame update
    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Le joueur appara�tra donc � cette nouvelle position
            playerSpawn.position = transform.position;
            //On d�truit le spawn car il nous sert plus � rien
            //Destroy(gameObject);
        }
    }
}