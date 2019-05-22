using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class flicker : MonoBehaviour
{
    public GameObject Light;

    private IEnumerator Start()
    {
        while (true)
        {
            Light.SetActive(false);
            yield return new WaitForSeconds(Random.Range(0f, 1f));
            Light.SetActive(true);
            yield return new WaitForSeconds(Random.Range(0f, 2f));
        }
    }
}