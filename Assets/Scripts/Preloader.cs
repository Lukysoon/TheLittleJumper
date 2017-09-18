using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float loadTime;
    public float minimumLogoTime = 3.0f; //Minimum time of that scene

    private void Start()
    {
        // Grab the only CanvasGrouú in the scene
        fadeGroup = FindObjectOfType<CanvasGroup>();

        // Start with black screen
        fadeGroup.alpha = 1;

        if (Time.time < minimumLogoTime)
            loadTime = minimumLogoTime;
        else
            loadTime = Time.time;
    }

    private void Update()
    {
        // Fade-in
        if (Time.time < minimumLogoTime)
        {
            fadeGroup.alpha = 1 - Time.time;
        }

        // Fade-out
        if (Time.time > minimumLogoTime && loadTime != 0)
        {
            fadeGroup.alpha = Time.time - minimumLogoTime;
            if(fadeGroup.alpha>= 1)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
