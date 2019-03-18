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

    // Takes dead from health script when it activates and sets dead in this script to the one in health.
    private void FixedUpdate()
    {
        dead = HealthSystem.dead;
    }

    // Shows the death menu when dead is true and starts toggle dead function.
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
    
    // Stops time when dead.
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
    
    // Restarts game when button on death menu is clicked, hides menu, and activates time.
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
    
    // Quits back to title menu, hides death menu, and resumes time.
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
