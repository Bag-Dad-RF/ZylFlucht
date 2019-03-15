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

    private void Update()
    {       
        if (Input.GetButtonDown("Pause") && CanPauseNotDead)
        {
            paused = togglePause();
            isShowing = !isShowing;
            menu.SetActive(isShowing);
        }
    }

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
 
