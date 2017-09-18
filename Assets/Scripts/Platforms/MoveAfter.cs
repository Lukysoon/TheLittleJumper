using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAfter : MonoBehaviour
{
    public float speedMoving;
    public float shift;
    public bool move;
    private int random;

    Rigidbody2D player;
    Rigidbody2D rb;
    Collider2D myCollider;
    public LayerMask layer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        random = Random.Range(0, 100);
        if (random < 50)
            speedMoving = -speedMoving;
    }

    void Update()
    {
        if (Physics2D.IsTouchingLayers(myCollider, layer) && player.velocity.y < 0)
            move = true;

        if (move)
            rb.velocity = new Vector2(speedMoving, 0);

        if (transform.position.x < -shift || transform.position.x > shift)
            Destroy(this.gameObject);
    }
}

