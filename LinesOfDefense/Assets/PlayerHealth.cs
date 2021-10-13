using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    public GameObject GameOver;
    public bool GameisOver = false;

    public HealthBarScript healthbar;
    


    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        GameOver.SetActive(false);
        GameisOver = false;
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            GameOver.SetActive(true);
            GameisOver = true;
            Time.timeScale = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
}
