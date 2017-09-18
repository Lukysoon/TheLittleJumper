using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
using DynamicLight2D;

public class SceneGameManager : MonoBehaviour
{
    Transform player;
    public static float playerPosY;
    public static float playerPosX;

    public GameObject playersLight;
    ExtendedFPSDisplay display;
    DynamicLight dynamic2DInicialize;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        display = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ExtendedFPSDisplay>();

        PlayerLight();
        Display();
    }

    void PlayerLight()
    {
        if (GameManager.playerLightCheck)
            playersLight.SetActive(true);

        else
            playersLight.SetActive(false);
    }

    void Display()
    {
        if (GameManager.ExtentedDisplayCheck)
            display.enabled = true;

        else
            display.enabled = false;
    }


    private void Update()
    {
        playerPosY = player.transform.position.y;
        playerPosX = player.transform.position.x;
    }
}
