using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersLightSet : MonoBehaviour
{
    public GameObject playersLightCheck;
    private bool playersLight;

    private void Start()
    {
        playersLight = GameManager.playerLightCheck;
        BOSquareChecking();
    }

    private void OnMouseDown()
    {
        TurnOffEffect();
    }

    private void TurnOffEffect()
    {
        playersLight = !playersLight;
        GameManager.playerLightCheck = playersLight;
        BOSquareChecking();
    }

    private void BOSquareChecking()
    {
        if (playersLight)
            playersLightCheck.SetActive(true);
        else
            playersLightCheck.SetActive(false);
    }
}
