﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Text T_Shop;
    public Text T_Articles1;
    public Text T_Articles2;
    public Text T_Articles3;
    public Text T_Articles4;
    public Text T_Articles5;
    public Text T_Error;
    public Animator animator;

    private float speed;
    private float jump;
    private int[] shop_price;
    private int[] shop_value;
    private bool[] shop_bonus;
    private bool damage;
    private bool heal;
    private string buttonName;
    private string textButtonName;
    private Mouvement playerController;
    private Animator playerAnimator;
    private inventory playerInventory;
    private Attack playerAttack;
    private Health playerHealth;

    void Start()
    {
        playerController = GameObject.Find("HeroKnight").GetComponent<Mouvement>();
        playerAnimator = GameObject.Find("HeroKnight").GetComponent<Animator>();
        playerInventory = GameObject.Find("DataManager").GetComponent<inventory>();
        playerAttack = GameObject.Find("HeroKnight").GetComponent<Attack>();
        playerHealth = GameObject.Find("HeroKnight").GetComponent<Health>();

        speed = playerController.Speed;
        jump = playerController.jump_power;

    }

    public void StartShop(Shop shop)
    {
        playerController.Speed = 0f;
        playerController.jump_power = 0f;
        playerAnimator.SetBool("CanMove", false);
        playerAnimator.SetBool("CanAttack", false);
        animator.SetBool("IsOpen", true);

        buttonName = "";
        damage = shop.damage;
        heal = shop.heal;
        shop_price = shop.price;
        shop_value = shop.value;
        T_Shop.text = shop.name;
        T_Articles1.text = shop.articles[0];
        T_Articles2.text = shop.articles[1];
        T_Articles3.text = shop.articles[2];
        T_Articles4.text = shop.articles[3];
        T_Articles5.text = shop.articles[4];

        if (damage)
        {
            if (LoadAndSaveData.instance != null)
            {
                shop_bonus = LoadAndSaveData.instance.bonus;
                for (int i = 0; i < 5; i++)
                {
                    if (shop_bonus[i])
                    {
                        buttonName = "Button" + (i + 1);
                        textButtonName = "TextButton" + (i + 1);
                        GameObject.Find(buttonName).GetComponent<Image>().fillCenter = false;
                        GameObject.Find(textButtonName).GetComponent<Text>().text = "Acheté";
                    }
                }
            }
        }
        else
        {
            if (LoadAndSaveData.instance != null)
            {
                shop_bonus = LoadAndSaveData.instance.bonus;
                for (int i = 0; i < 5; i++)
                {
                    buttonName = "Button" + (i + 1);
                    textButtonName = "TextButton" + (i + 1);
                    GameObject.Find(buttonName).GetComponent<Image>().fillCenter = true;
                    GameObject.Find(textButtonName).GetComponent<Text>().text = "Acheter";
                }
            }
        }
    }

    public void CloseShop()
    {
        playerController.Speed = speed;
        playerController.jump_power = jump;
        playerAnimator.SetBool("CanMove", true);
        playerAnimator.SetBool("CanAttack", true);
        playerAnimator.ResetTrigger("attack0");
        playerAnimator.ResetTrigger("attack1");
        playerAnimator.ResetTrigger("attack2");
        animator.SetBool("IsOpen", false);
        T_Error.text = "";
    }

    public void Buy(GameObject button)
    {
        if (button.name == "Button1") Check(0);
        else if (button.name == "Button2") Check(1);
        else if (button.name == "Button3") Check(2);
        else if (button.name == "Button4") Check(3);
        else Check(4);
    }

    private void Check(int id)
    {
        if (id == 4 && heal && shop_price[id] <= playerInventory.nb_coins)
        {
            playerInventory.AddPotions();
            playerInventory.SuppCoins(shop_price[id]);
            T_Error.text = "";
        }
        else
        {
            if (damage && shop_price[id] <= playerInventory.nb_coins && !shop_bonus[id])
            {
                buttonName = "Button" + (id + 1);
                textButtonName = "TextButton" + (id + 1);
                playerAttack.UpgradeDamage(shop_value[id]);
                playerInventory.SuppCoins(shop_price[id]);
                shop_bonus[id] = true;
                LoadAndSaveData.instance.bonus = shop_bonus;
                GameObject.Find(buttonName).GetComponent<Image>().fillCenter = false;
                GameObject.Find(textButtonName).GetComponent<Text>().text = "Acheté";
                T_Error.text = "";
            }
            else if (damage && shop_bonus[id])
            {
                T_Error.text = "Vous avez déjà acheté ce bonus !";
            }
            else if (heal && playerHealth.PV_max > playerHealth.PV && shop_price[id] <= playerInventory.nb_coins)
            {
                playerHealth.AddPV(shop_value[id]);
                playerInventory.SuppCoins(shop_price[id]);
                T_Error.text = "";
            }
            else if (heal && playerHealth.PV_max == playerHealth.PV && shop_price[id] <= playerInventory.nb_coins)
            {
                T_Error.text = "Votre santé est au maximum !";
            }
            else
                T_Error.text = "Vous n'avez pas assez de moules à gars !";
        }
    }

    public bool[] GetBonus() { return shop_bonus; }
}