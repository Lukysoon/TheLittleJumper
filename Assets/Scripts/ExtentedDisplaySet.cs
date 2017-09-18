using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtentedDisplaySet : MonoBehaviour
{
    public GameObject displayCheck;
    private bool display;

    private void Start()
    {
        display = GameManager.ExtentedDisplayCheck;
        BOSquareChecking();
    }

    private void OnMouseDown()
    {
        TurnEffect();
    }

    private void TurnEffect()
    {
        display = !display;
        GameManager.ExtentedDisplayCheck = display;
        BOSquareChecking();
    }

    private void BOSquareChecking()
    {
        if (display)
            displayCheck.SetActive(true);
        else
            displayCheck.SetActive(false);
    }
}
