using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {
    
    public Rigidbody2D rb;
    public float speed;

    public void Start() {
        rb = GetComponent<Rigidbody2D>();
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
}
