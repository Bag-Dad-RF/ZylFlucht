using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public UnityEngine.UI.Image[] Hearts;

    public AudioClip DeathSound;
    public AudioClip HurtSound;

    public AudioSource DeathSource;
    public AudioSource HurtSource;
    
    public int Health;
    public int NumOfHearts;

    public bool NotInvincible;
    public bool OverDose;
    public static bool CanPauseNotDead;
    public static bool dead;
 
    public Sprite FullHeart;
    public Sprite EmptyHeart;


    // Sets bools.
    void Start()
    {
        NotInvincible = true;
        dead = false;
        DeathSource.clip = DeathSound;
        HurtSource.clip = HurtSound;
    }

    // Sets the number of hearts and health and their interaction between each other so when health changes hearts do as well
    void FixedUpdate()
    {
        OverDose = PowerUps.Overdose;
        
        if (Health > NumOfHearts)
        {
            Health = NumOfHearts;
        }
        
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i < Health)
            {
                Hearts[i].sprite = FullHeart;
            }
            else
            {
                Hearts[i].sprite = EmptyHeart;
            }
            
            if (i < NumOfHearts)
            {
                Hearts[i].enabled = true;
            }
            else
            {
                Hearts[i].enabled = false;
            }
        }

        // Sets dead to true when health equals zero so death menu script can start.
        
        if (OverDose)
        {
            DeathSource.Play();
            Health = 0;
        }
        
        if (Health <= 0)
        {
            DeathSource.Play();
            dead = true;
        }
    }

    // Deceases health when colliding with an enemy and give invincibility frames and kills you when you fall.
    private IEnumerator OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bad"))
        {
            Health = Health - 1;
            HurtSource.Play();
            NotInvincible = false;
            yield return new WaitForSeconds((float) .8);
        }
        
        if (other.gameObject.CompareTag("Low"))
        {
            Health = 0;
        }
    }

    // Decreases health when staying on enemy after invincibility frames stop from initial hit.
    private IEnumerator OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Bad") && NotInvincible)
        {
            Health = Health - 1;
            HurtSource.Play();
            NotInvincible = false;
            yield return new WaitForSeconds((float) .8);
            NotInvincible = true;
        }
    }

    void OnParticleCollision(GameObject other)
    {
        
    }
}
