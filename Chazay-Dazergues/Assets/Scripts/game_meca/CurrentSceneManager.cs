using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public static CurrentSceneManager instance;

    public int levelToUnlock;

    private Transform playerSpawn;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de CurrentSceneManager dans la scène");
            return;
        }

        instance = this;
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Le joueur apparaîtra donc à cette nouvelle position
            playerSpawn.position = transform.position;
            //On détruit le spawn car il nous sert plus à rien
            //Destroy(gameObject);
        }
    }
}
