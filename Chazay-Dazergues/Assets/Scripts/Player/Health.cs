using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int PV;
    public int PV_max;

    public static Health instance;

    public HealthBar healthbar;

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

    void Start()
    {
        PV = PV_max;
        healthbar.SetMaxHealth(PV_max);
    }

    //Uniquement pour des tests
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
            PV = PV_max;
    }
}