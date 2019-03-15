using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
