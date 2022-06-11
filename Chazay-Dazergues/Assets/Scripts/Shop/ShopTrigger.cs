using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    public Shop shop;
    private bool IsAllow;

    void Start()
    {
        IsAllow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && IsAllow)
        {
            OpenShop();
        }
        if (Input.GetKeyDown("r"))
            FindObjectOfType<ShopManager>().CloseShop();
    }

    void OnTriggerEnter2D()
    {
        IsAllow = true;
        shop.bonus = GameObject.Find("CurrentSceneManager").GetComponent<inventory>().GetBonus();
    }

    void OnTriggerExit2D()
    {
        IsAllow = false;
    }

    public void OpenShop()
    {
        FindObjectOfType<ShopManager>().StartShop(shop);
    }

    public void SetBonusOrigin(int id)
    {
        shop.bonus[id] = true;
    }
}