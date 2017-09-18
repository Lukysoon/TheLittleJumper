using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DevelopersSettings : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Develop");
    }
}
