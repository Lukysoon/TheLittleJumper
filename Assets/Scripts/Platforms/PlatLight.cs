using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatLight : MonoBehaviour
{
    public PolygonCollider2D polygonPlatform;
    public PolygonCollider2D polygonLine;

    void Update()
    {
        if ((SceneGameManager.playerPosY > transform.position.y - 0.06) && (SceneGameManager.playerPosY < transform.position.y + 0.06) &&
            (SceneGameManager.playerPosX > transform.position.x - 0.5 && SceneGameManager.playerPosX < transform.position.x + 0.5))
        {
            polygonPlatform.enabled = false;
            //polygonLine.enabled = true;
        }
        else
        {
            polygonPlatform.enabled = true;
            //polygonLine.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //polygon.enabled = false;
        }
    }
}
