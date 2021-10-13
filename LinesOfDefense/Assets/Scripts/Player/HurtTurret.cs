using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtTurret : MonoBehaviour
{
    public GameObject[] Hearts;
    public int lives = 5;
    public AudioSource HurtCanon;
    public AudioSource DeathCanon;


    public void TakeDamage(int damage)
    {
       
            if(lives > 0)
            {
                HurtCanon.Play();
                Destroy(Hearts[lives - damage]);
                lives -= 1;
            }
            else
            {
                DeathCanon.Play();
                GetComponent<Renderer>().enabled = false;
                Destroy(gameObject, 1.0f);
            }
        

        
    }
}
