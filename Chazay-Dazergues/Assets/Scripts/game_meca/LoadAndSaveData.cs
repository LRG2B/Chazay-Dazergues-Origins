using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{

    public static LoadAndSaveData instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'instance de LoadAndSavaData dans la scène");
            return;
        }

        instance = this;
    }

    void Start()
    {
        //getters
        //0 est une default value au cas où
        inventory.instance.nb_coins = PlayerPrefs.GetInt("coinsCount", 0);
        inventory.instance.nb_potions = PlayerPrefs.GetInt("potionsCount", 0);
    }


    public void SaveData()
    {
        //setters
        PlayerPrefs.SetInt("coinsCount", inventory.instance.nb_coins);
        PlayerPrefs.SetInt("potionsCount", inventory.instance.nb_potions);
    }
}
