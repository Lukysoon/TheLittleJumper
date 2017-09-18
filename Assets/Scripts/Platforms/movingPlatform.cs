using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    private float shift;
    public float speedMoving;
    public float pauseTimeSet;
    private float pauseTime;

    public bool pause;

    Rigidbody2D rb;
    Vector2 moveVel;
    Vector2 pauseVel;

    private void Start()
    {
        pauseTime = pauseTimeSet;
        pauseVel = new Vector2(0, 0);
        rb = GetComponent<Rigidbody2D>();
        shift = 1.7f;
    }

    private void Update()
    {
        rb.velocity = new Vector2(speedMoving, 0);

        if (transform.position.x < -shift && rb.velocity.x < 0)
        {
            rb.velocity = pauseVel;
            pause = true;
        }

        if (transform.position.x > shift && rb.velocity.x > 0)
        {
            rb.velocity = pauseVel;
            pause = true;
        }

        if (pause)
            Pause();
    }

    void Pause()
    {
        pauseTime -= Time.deltaTime;
        if (pauseTime < 0)
        {
            pause = false;
            speedMoving = -speedMoving;
            rb.velocity = new Vector2(speedMoving, 0);
            pauseTime = pauseTimeSet;
        }
    }
}
