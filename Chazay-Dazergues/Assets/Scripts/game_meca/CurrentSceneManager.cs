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
        else
        {
            Destroy(this);
        }

        instance = this;
        //playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }
}
