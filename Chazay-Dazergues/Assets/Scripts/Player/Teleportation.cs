using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject zone_tp;

    public void OnTriggerEnter2D()
    {
        GameObject.Find("HeroKnight").transform.position = zone_tp.transform.position;
    }
}
