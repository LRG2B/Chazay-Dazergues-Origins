using UnityEngine;

public class UpdateTextCoins : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = inventory.instance.nb_coins.ToString();
    }
}