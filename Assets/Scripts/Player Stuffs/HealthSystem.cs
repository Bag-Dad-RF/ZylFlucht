using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int Health;
    public int NumOfHearts;

    public bool NotInvincible;
    
    public UnityEngine.UI.Image[] Hearts;
 
    public Sprite FullHeart;
    public Sprite EmptyHeart;


    void Start()
    {
        NotInvincible = true;
    }


    void FixedUpdate()
    {
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

        if (Health == 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    private IEnumerator OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bad"))
        {
            Health = Health - 1;
            NotInvincible = false;
            yield return new WaitForSeconds((float) .8);
        }
    }

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