using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Inventory sera un singleton
//Pour qu'on puisse récupérer des objets
public class inventory : MonoBehaviour
{
    public int nb_coins;
    public int nb_potions;

    private bool[] damage_bonus;

    // public Text coinsCountText;
    //Création du singleton
    public static inventory instance;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
            damage_bonus = GameObject.Find("Black Smith").GetComponent<ShopTrigger>().shop.bonus;
    }

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
            //Création de problèmes
            //DontDestroyOnLoad(instance);
        }
    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire2")) // correspont au clic droit de la souris ( en utillisant ces clé la le jeu et compatible manette )
        {
            UsePotion();
        }
        if(Input.GetKeyDown("p"))
        {
            nb_potions += 50;
        }
    }

    public void AddCoins(int count)
    {
        nb_coins += count;
    }

    public void SuppCoins(int count) { nb_coins -= count; }
    public void AddPotions()
    {
        nb_potions++;
    }

    private void UsePotion()
    {
        if (nb_potions != 0)
        {
            nb_potions--;
            Health.instance.AddPV(10);
        }
    }

    public bool[] GetBonus()
    {
        return damage_bonus;
    }

    public bool GetBonusById(int id)
    {
        return damage_bonus[id];
    }

    public void SetBonus(bool[] bonus)
    {
        damage_bonus = bonus;
    }

}
