using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {
    
    public Rigidbody2D rb;
    public float speed;

    float paddleHeight;

    public void Start() {
        rb = GetComponent<Rigidbody2D>();

        Collider2D collider = GetComponent<Collider2D>();
        paddleHeight = collider.bounds.size.y;
    }

    public void FixedUpdate() {
        KeyCode upKey = KeyCode.W;
        KeyCode downKey = KeyCode.S;
        if (transform.localPosition.x > 0) {
            upKey = KeyCode.UpArrow;
            downKey = KeyCode.DownArrow;
        }
        
        if (Input.GetKey(upKey)) {
            rb.velocity = Vector2.up * speed;
        }
        else if (Input.GetKey(downKey)) {
            rb.velocity = Vector2.down * speed;
        }
        else rb.velocity = Vector2.zero;
    }

    private void LateUpdate() {
        float topBound = 0.95f - paddleHeight / 2;
        float bottomBound = -0.95f + paddleHeight / 2;

        float clampedY = Mathf.Clamp(transform.localPosition.y, bottomBound, topBound);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedY, transform.localPosition.z);
    }

    public void ResetPosition() {
        transform.localPosition = new Vector2(transform.localPosition.x, 0);
    }
}
