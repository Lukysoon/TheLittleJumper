using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    PlayerRaycast raycast;
    public float velocityY;
    private float velocityX;
    public float gravity;

    private float timeRocket;
    public float timeRocketSet;

    public GameObject particles;

    public float moveSpeed;
    public float jumpPower;

    public LayerMask rocketLayer;
    public LayerMask jumpLayer;
    public LayerMask groundLayer; // Insert the layer here.

    public bool isGrounded;
    public bool isGroundedJump;
    public bool isGroundedRocket;
    public bool rocketBurst;

    void Start()
    {
        timeRocket = timeRocketSet;
        particles.SetActive(false);
    }

    void FixedUpdate()
    {
        if (transform.position.x < -2.35)
            transform.position = new Vector2(2.34f, transform.position.y);

        if (transform.position.x > 2.35)
            transform.position = new Vector2(-2.34f, transform.position.y);


        if (velocityY <= 0)
        {
            if (PlayerRaycast.hit.collider != null)
                Debug.Log(PlayerRaycast.hit.collider.tag);

            if (PlayerRaycast.hit.collider != null && PlayerRaycast.hit.collider.tag == "classic")
                isGrounded = true;

            else if (PlayerRaycast.hit.collider != null && PlayerRaycast.hit.collider.tag == "jump")
                isGroundedJump = true;

            else if (PlayerRaycast.hit.collider != null && PlayerRaycast.hit.collider.tag == "rocket")
                isGroundedRocket = true;
        }


        if (isGrounded)
        {
            velocityY = jumpPower;
            isGrounded = false;
        }

        else if (isGroundedJump)
        {
            velocityY = jumpPower + 0.07f;
            isGroundedJump = false;
        }

        else if (isGroundedRocket)
            rocketBurst = true;

        // Jump phase
        else
        {
            velocityY -= gravity * Time.deltaTime;
        }

        // RocketBurst
        if (rocketBurst)
        {
            timeRocket -= Time.deltaTime;

            velocityY = jumpPower;
            particles.SetActive(true);

            if (timeRocket < 0)
            {
                rocketBurst = false;
                particles.SetActive(false);
                timeRocket = timeRocketSet;
            }
        }

        // Akceletrmetr
        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;
        //dir.y = Input.acceleration.y;
        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;
        transform.Translate(dir * moveSpeed);


        // Klávesnice
        float move = Input.GetAxis("Horizontal");
        velocityX = move * 0.2f;

        transform.Translate(new Vector2(velocityX, velocityY));
    }
}