using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Projectile : MonoBehaviour

{
    public GameObject projectile;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject)
        {
            Destroy(projectile);
        }

    }

    void Update()
    {
        Destroytimer();
    }

    private void Destroytimer()
    {
        Destroy(projectile,100);
    }

    
    
}

