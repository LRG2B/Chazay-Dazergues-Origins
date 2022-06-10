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

    private float time = 1;
    private bool canChangeDay = true;

    // Update is called once per frame
    private void Update()
    {
        if (time > 100)
        {
            time = 0;
        }
        //500
        if ((int) time == 100 && canChangeDay)
        {
            canChangeDay = false;
            days++;
        }
        //255
        if ((int) time == 51)
        {
            canChangeDay = true;
        }

        time += Time.deltaTime;
        light.GetComponent<Light2D>().color = lightColor.Evaluate(time * 0.02f);

        //Pour 500 secondes
        //light.GetComponent<Light2D>().color = lightColor.Evaluate(time * 0.002f);
    }
}
