using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Changes scene from main menu to first level.
    public void Scene()
    {
        SceneManager.LoadScene("S1L1");
    }
}
