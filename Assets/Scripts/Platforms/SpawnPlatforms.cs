using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    public GameObject classicPlatform;
    public GameObject jump;
    public GameObject move;
    public GameObject moveAfter;
    public GameObject rocket;

    public float maxSpawnSpan;
    private float startSpan;

    public int level;

    private float randomPosY;
    private float randomPosX;
    private int randomType;
    Vector3 platformPosition;
    Vector3 elementPosition;

    private int a;
    private int b;
    private int c;
    private int d;


    void Start()
    {
        startSpan = -3.1f;
        for (int i = 0; i < 21; i++) //Default = 21 !!!
        {
            randomPosX = Random.Range(-1.7f, 1.7f);

            platformPosition = new Vector3(randomPosX, startSpan, 0);
            Instantiate(classicPlatform, platformPosition, transform.rotation);
            startSpan += maxSpawnSpan;
        }
        maxSpawnSpan += 0.19f; // Spawn collider scale
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "classic")
        {
            randomPosX = Random.Range(-1.7f, 1.7f);
            randomType = Random.Range(0, 1000);

            switch (GameManager.level)
            {
                case 1:
                    // RandomType ---> 0 - a - b - c
                    a = 100;
                    b = 200;

                    maxSpawnSpan = 0.2f;
                    break;
                case 2:
                    // RandomType ---> 0 - a - b - c

                    a = 50;
                    b = 200;
                    c = 300;
                    d = 320;

                    maxSpawnSpan = 0.4f;

                    break;
                case 3:
                    // LEVEL 3

                    break;
            }

            platformPosition = new Vector3(randomPosX, transform.position.y + maxSpawnSpan, 0);

            if (randomType < a)
                Instantiate(jump, platformPosition, transform.rotation);

            else if (randomType > a && randomType < b)
                Instantiate(move, platformPosition, transform.rotation);

            else if (randomType > b && randomType < c)
                Instantiate(moveAfter, platformPosition, transform.rotation);

            else if (randomType > c && randomType < d)
                Instantiate(rocket, platformPosition, transform.rotation);

            else
                Instantiate(classicPlatform, platformPosition, transform.rotation);
        }
    }
}


//Instantiate(classicPlatform, platformPosition, transform.rotation);

//if (randomType < bigGreenOccurence)
//{
//    platformPosition = new Vector3(randomPos, transform.position.y + spawnSpan, -1);
//    elementPosition = new Vector3(randomPos, transform.position.y + spawnSpan + 0.5f, 0);
//    Instantiate(greenElement, elementPosition, transform.rotation);
//}

//if (randomType > doubleBlueOccurence)
//    platformPosition = new Vector3(randomPos, transform.position.y + spawnSpan, -1);
//{
//    elementPosition = new Vector3(randomPos, transform.position.y + spawnSpan + 0.5f, -1);
//    Instantiate(blueElement, elementPosition, transform.rotation);
//}
