using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Rigidbody2D rb;
    private PlayerController playerCont;    //OBJECT TO TRACK IS PLAYER

    private Vector2 velocity;
    private Vector3 zeroVel;
    private int score;

    public float smoothTime;
    private float playerHeightY;        //HEIGHT AT WHICH CAMERA WILL ADJUST TO
    private float currentCameraHeightY;
    private float newCameraPosition;

    private void Start()
    {
        playerCont = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void LateUpdate()
    {
        currentCameraHeightY = transform.position.y;

        playerHeightY = playerCont.transform.position.y;

        if (playerHeightY > currentCameraHeightY && playerCont.velocityY > 0)
        {
            newCameraPosition = Mathf.SmoothDamp(currentCameraHeightY, playerHeightY, ref velocity.y, smoothTime);
            transform.position = new Vector3(transform.position.x, newCameraPosition, transform.position.z);
        }
    }
}
