using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Death : MonoBehaviour
{

    public GameObject deathmenu;
    
    public bool dead;
    private bool isShowing;
    private bool stop;
    private bool hide = true;

    private void FixedUpdate()
    {
        dead = HealthSystem.dead;
    }

    private void Update()
    {      
        if (dead)
        {
            stop = toggledead();
            isShowing = !isShowing;
            deathmenu.SetActive(isShowing);
            dead = false;
        }
    }
    
    bool toggledead()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            return (false);
        }
        else
        {
            Time.timeScale = 0f;
            return (true);
        }
    }
    
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        
        stop = toggledead();
        isShowing = !isShowing;
        deathmenu.SetActive(isShowing);
        
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }
    
    public void Quit()
    {
        SceneManager.LoadScene("Title Screne");
        stop = toggledead();
        isShowing = !isShowing;
        deathmenu.SetActive(isShowing);
        
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }
    
}
