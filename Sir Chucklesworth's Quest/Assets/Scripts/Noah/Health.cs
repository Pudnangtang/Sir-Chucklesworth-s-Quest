using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public PlayerHealth PlayerHealth;

    void Update()
    {

        health = PlayerHealth.health;
        maxHealth = PlayerHealth.maxHealth;

        if(health > maxHealth)
        {
            health = maxHealth;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled=false;
            }
        }
    }
}
