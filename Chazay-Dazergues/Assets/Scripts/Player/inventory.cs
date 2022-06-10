using UnityEngine;
using UnityEngine.UI;

//Inventory sera un singleton
//Pour qu'on puisse récupérer des objets
public class inventory : MonoBehaviour
{
    public int nb_coins;
    public int nb_potions;

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
    }

    public void AddCoins(int count)
    {
        nb_coins += count;
    }

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

}
