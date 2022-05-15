using UnityEngine;
using UnityEngine.UI;

//Inventory sera un singleton
//Pour qu'on puisse récupérer des objets
public class inventory : MonoBehaviour
{
    public int CoinsCount;

    // public Text coinsCountText;
    //Création du singleton
    public static inventory instance;

    private void Awake()
    {

        //If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Debug.LogWarning("manager  inventory deja existant ");
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void AddCoins(int count)
    {
        CoinsCount += count;
    }
}
