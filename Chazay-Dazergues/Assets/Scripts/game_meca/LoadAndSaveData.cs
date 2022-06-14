using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;
    public bool[] bonus;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'instance de LoadAndSavaData dans la scène");
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //getters
        //0 est une default value au cas où
        inventory.instance.nb_coins = PlayerPrefs.GetInt("coinsCount", 0);
        inventory.instance.nb_potions = PlayerPrefs.GetInt("potionsCount", 0);
        bonus = GameObject.Find("Black Smith").GetComponent<ShopTrigger>().shop.bonus;
    }

    public void SaveData()
    {
        //setters
        PlayerPrefs.SetInt("coinsCount", inventory.instance.nb_coins);
        PlayerPrefs.SetInt("potionsCount", inventory.instance.nb_potions);
        PlayerPrefs.SetInt("levelReached", CurrentSceneManager.instance.levelToUnlock);
    }
}
