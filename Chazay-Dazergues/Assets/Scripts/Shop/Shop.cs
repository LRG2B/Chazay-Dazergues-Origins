using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Shop
{
    public bool damage;
    public bool heal;
    public string name;
    [TextArea(3, 10)]
    public string[] articles;
    public int[] price;
    public int[] value;
}