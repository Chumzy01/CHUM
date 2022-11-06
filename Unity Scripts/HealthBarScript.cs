using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //CREATE A SLIDER AND PUT AS SLIDER
    public Slider slider;
    
    //THE GRADIENT COME WITH THE SLIDER. PUT IT HERE
    public Gradient gradient;

    //FILL IMAGE COMES WITH THE SLIDER TOO. PUT IT HERE
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
/*add this in your player or enemy script for health, and delete it from this script.

    public int maxHealth;
    public int currentHealth;

    //PUT THE GAMEOBJECT WITH HEALTH BAR HERE
    public HealthBar healthBar;

    //IN YOUR START FUNCTION
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    //FUNCTION TO TAKE DAMAGE WHEN HIT
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    
    */