using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int PV;
    int PV_max;

    public static Health instance;

    // Start is called before the first frame update
    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.LogWarning("manager Health deja existant ");
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    

    public void AddPV(int value)
    {
        PV += value;
    }
}
