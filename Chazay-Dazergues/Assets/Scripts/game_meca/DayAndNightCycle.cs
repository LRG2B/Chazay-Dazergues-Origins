using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayAndNightCycle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Gradient lightColor;
    [SerializeField] private GameObject light;

    private int days;
    //Getters (Days prend les valeurs de days)
    public int Days => days;

    public float time = 50;
    private bool canChangeDay = true;

    // Update is called once per frame
    private void Update()
    {
        if (time > 500)
        {
            time = 0;
        }

        if ((int) time == 500 && canChangeDay)
        {
            canChangeDay = false;
            days++;
        }

        if ((int) time == 255)
        {
            canChangeDay = true;
        }

        time += Time.deltaTime;
        light.GetComponent<Light2D>().color = lightColor.Evaluate(time + 0.002f);
    }
}
