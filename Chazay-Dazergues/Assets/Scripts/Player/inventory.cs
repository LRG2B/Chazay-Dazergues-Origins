using UnityEngine;
using UnityEngine.UI;

//Inventory sera un singleton
//Pour qu'on puisse r�cup�rer des objets
public class Inventory : MonoBehaviour
{
    public int CoinsCount;

    // public Text coinsCountText;
    //Cr�ation du singleton
    public static Inventory instance;

    private void Awake()
    {

        //If there is an instance, and it's not me, delete myself.

        if (instance != null && instance != this)
        {
            Debug.LogWarning("manager  Inventory deja existant ");
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    public void AddCoins(int count)
    {
        CoinsCount += count;
        // coinsCountText.text = CoinsCount.ToString();
    }
}
