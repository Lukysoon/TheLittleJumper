using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    GameManager script;

    public Text countText;
    private float score;

    // Use this for initialization
    void Start()
    {
        score = 0;
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        score = Mathf.Round(transform.position.y * 10) * 20;
        SetCountText();
        if (score < 5000)
            GameManager.level = 1;

        if (score > 5000 && score < 20000)
            GameManager.level = 2;
    }

    void SetCountText()
    {
        countText.text = "Score: " + score.ToString();
    }
}
