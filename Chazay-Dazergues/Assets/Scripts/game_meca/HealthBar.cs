using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar bar;

    public void Start()
    {
        bar = this;
    }

    //Slider permet de récupérer les valeurs de la barre de vie
    public Slider slider;

    //Initialisation de la barre de vie au max
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //Montre combien il lui reste de points de vies
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}