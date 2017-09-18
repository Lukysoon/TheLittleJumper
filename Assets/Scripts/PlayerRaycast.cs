using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour {

    public static RaycastHit2D hit;
    public float rayDist;
    public LayerMask layer;

	// Update is called once per frame
	void FixedUpdate () {
        hit = Physics2D.Raycast(transform.position, Vector2.right, rayDist, layer);
        Debug.DrawRay(transform.position, Vector2.right, Color.cyan);
    }
}
