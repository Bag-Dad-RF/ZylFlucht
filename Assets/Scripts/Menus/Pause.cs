using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject menu;
    
    private bool isShowing;
    private bool paused = false;
    private bool hide = true;
    public bool CanPauseNotDead = true;

    // Brings up pause menu and hides it when esc is pressed and you are not dead. Also starts toggle pause function.
    private void Update()
    {       
        if (Input.GetButtonDown("Pause") && CanPauseNotDead)
        {
            paused = togglePause();
            isShowing = !isShowing;
            menu.SetActive(isShowing);
        }
    }

    
    // Stops time and starts it again
    bool togglePause()
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

    // Restarts game when button on menu is clicked, hides menu, and activates time.
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        
        paused = togglePause();
        isShowing = !isShowing;
        menu.SetActive(isShowing);
        
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }

    // Quits back to title menu, hides death menu, and resumes time.
    public void Quit()
    {
        SceneManager.LoadScene("Title Screne");
        paused = togglePause();
        isShowing = !isShowing;
        menu.SetActive(isShowing);
        
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }

    // Alternative to esc. Hides menu and starts time when clicked.
    public void Continue()
    {
        paused = togglePause();
        isShowing = !isShowing;
        menu.SetActive(isShowing);
        
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
    }
}
 
