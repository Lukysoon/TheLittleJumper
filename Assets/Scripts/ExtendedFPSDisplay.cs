using UnityEngine;

public class ExtendedFPSDisplay : MonoBehaviour
{
    [Header("Display Options")]
    [SerializeField]
    Color textColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);

    [Range(4f, 60f)]
    [Tooltip("Number of lines that fit into screen. Smaller number -> bigger font.")]
    [SerializeField]
    int fontSizeRatio = 40;
    
    [Range(0.01f, 1f)]
    [Tooltip("Something like mini average. If equals 1 -> fps will be displayed every frame (accurate - but with flickering), if equals 0.01 it will have a bit of delay (but no flickering).")]
    [SerializeField]
    float smoothFPSInterval = 0.1f;

    [Header("Average Display")]
    [Tooltip("After this amount of frames average FPS will be counted.")]
    [SerializeField]
    int averageCounterInterval = 1000; // after this amout of frames will be counted average fps
    int counter = 1000; // iterator
    float averageCounter = 0f; // it counts fps
    float averageValue = 0f; // will be displayed

    [Header("Limiting FPS")]
    [SerializeField]
    bool limitFPS = false;
    [SerializeField]
    int fpsLimitValue = 35;

    float smoothDeltaTime = 0.0f;

    string quality;
    string version;

    // screen values
    GUIStyle style;
    Rect rect;

    private void Start()
    {
        quality = QualitySettings.names[QualitySettings.GetQualityLevel()];
        version = Application.version;

        int width = Screen.width;
        int height = Screen.height;

        style = new GUIStyle();
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = height / fontSizeRatio;
        style.normal.textColor = textColor;

        rect = new Rect(0, 0, width, height);
    }

    void Awake()
    {
        if(limitFPS)
            Application.targetFrameRate = fpsLimitValue;
        else
            Application.targetFrameRate = -1; // set default value
    }

    void Update()
    {
        smoothDeltaTime += (Time.deltaTime - smoothDeltaTime) * smoothFPSInterval;
    }

    void OnGUI()
    {
        float milliseconds = smoothDeltaTime * 1000.0f;
        float fps = 1.0f / smoothDeltaTime;

        if (counter < 1)
        {
            averageValue = averageCounter / averageCounterInterval;
            counter = averageCounterInterval;
            averageCounter = 0f;
        }
        else
        {
            averageCounter += fps;
            counter--;
        }

        string text = string.Format("{0:0.0} ms ({1:0.} fps)\nAverage: {2:0.} fps\nQuality: {3}\nVersion: {4}\nlevel: {5}\ndestroyed platforms: {6}", milliseconds, fps, averageValue, quality, version, GameManager.level, GameManager.destroyedPlatforms);
        GUI.Label(rect, text, style);
    }
}