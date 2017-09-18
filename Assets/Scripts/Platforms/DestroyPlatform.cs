using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlatform : MonoBehaviour
{
    private void Start()
    {
        GameManager.destroyedPlatforms = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.destroyedPlatforms++;

        if (collision.gameObject.tag == "Player")
            SceneManager.LoadScene("Restart");

        Destroy(collision.gameObject);
    }
}
