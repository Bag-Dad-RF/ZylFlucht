using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    
    public static float JumpHeight;
    public static float Speed;


    private void Start()
    {
        JumpHeight = 17;
        Speed = 50;
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JumpPower"))
        {
            other.gameObject.SetActive(false);
            JumpHeight = 34;
            yield return new WaitForSeconds(10);
            JumpHeight = 17; 
        }

        if (other.gameObject.CompareTag("SanicBoi"))
        {
            other.gameObject.SetActive(false);
            Speed = 75;
            yield return new WaitForSeconds(10);
            Speed = 50;
        }

        if (other.gameObject.CompareTag("MarioStar"))
        {
            
        }

        if (other.gameObject.CompareTag("Cocaine"))
        {
            other.gameObject.SetActive(false);
            Speed = 125;
            JumpHeight = 25;
            yield return new WaitForSeconds(10);
            Speed = 50;
            JumpHeight = 17;
            
        }
    }
}
