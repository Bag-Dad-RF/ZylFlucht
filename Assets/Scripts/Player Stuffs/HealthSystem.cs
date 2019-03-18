using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int Health;
    public int NumOfHearts;

    public bool NotInvincible;
    public static bool CanPauseNotDead;
    public static bool dead;
    public bool OverDose;
    
    public UnityEngine.UI.Image[] Hearts;
 
    public Sprite FullHeart;
    public Sprite EmptyHeart;


    // Sets bools.
    void Start()
    {
        NotInvincible = true;
        dead = false;
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
            Health = 0;
        }
        
        if (Health == 0)
        {
            dead = true;
        }
    }

    // Deceases health when colliding with an enemy and give invincibility frames and kills you when you fall.
    private IEnumerator OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bad"))
        {
            Health = Health - 1;
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
            NotInvincible = false;
            yield return new WaitForSeconds((float) .8);
            NotInvincible = true;
        }
    }
}