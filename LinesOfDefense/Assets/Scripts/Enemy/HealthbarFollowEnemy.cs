using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarFollowEnemy : MonoBehaviour
{
    public GameObject[] EnemyHearts;
    public int lives = 3;
    public AudioSource HurtEnemy;
    public AudioSource DeathEnemy;

    

   


    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Bullet"))
        {
            
            if (lives > 0)
            {
                HurtEnemy.Play();
                Destroy(EnemyHearts[lives - 1]);
                lives -= 1;
            }
            else
            {
                DeathEnemy.Play();
                GetComponent<Renderer>().enabled = false;
                Destroy(gameObject, 1.0f);
            }
        }
        

    }

    






}
