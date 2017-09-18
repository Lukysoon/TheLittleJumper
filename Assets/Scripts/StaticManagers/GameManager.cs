using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool ExtentedDisplayCheck = true;
    public static bool playerLightCheck = true;
    public static int score;
    public static int level;
    public static int destroyedPlatforms;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
