using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{   
    public int PV = 100;
    public int PV_max = 100;

    public static Health instance;

    public HealthBar healthbar;

    // Start is called before the first frame update
    void Awake()
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

    void Start()
    {
        PV = PV_max;
        healthbar.SetMaxHealth(PV_max);
    }

    //Uniquement pour des tests - Inflige des dégâts
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        PV -= damage;
        healthbar.SetHealth(PV);
    }

    public void AddPV(int value)
    {
        PV += value;
        healthbar.SetHealth(PV);
        if (PV > PV_max)
        {
            PV = PV_max;
        }
    }
}