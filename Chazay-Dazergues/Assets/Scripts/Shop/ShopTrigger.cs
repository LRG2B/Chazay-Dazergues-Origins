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
            TriggerShop();
        }
        if (Input.GetKeyDown("r"))
            FindObjectOfType<ShopManager>().CloseShop();
    }

    void OnTriggerEnter2D()
    {
        IsAllow = true;
    }

    void OnTriggerExit2D()
    {
        IsAllow = false;
    }

    public void TriggerShop()
    {
        FindObjectOfType<ShopManager>().StartShop(shop);
    }
}