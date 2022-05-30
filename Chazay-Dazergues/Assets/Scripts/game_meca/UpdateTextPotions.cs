using UnityEngine;

public class UpdateTextPotions : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        //print(Inventory.instance.CoinsCount.ToString());
        gameObject.GetComponent<UnityEngine.UI.Text>().text = inventory.instance.nb_potions.ToString();
    }
}