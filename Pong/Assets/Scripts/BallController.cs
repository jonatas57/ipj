using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public float speed;
    public Vector2 direction;

    Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        ResetBall();
    }

    private void FixedUpdate() {
        rb.velocity = direction * speed;
    }

    public void ResetBall() {
        float x = Random.value > 0.5f ? 1 : -1;
        float y = 0;

        while (y < 0.2f && y > -0.2f) {
            y = Random.Range(-1, 1);
        }

        direction = new Vector2(x, y);
        direction = direction.normalized;

        transform.localPosition = Vector3.zero;
        speed = 2;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Paddle")) {
            direction.x *= -1;
        }
        else if (collision.CompareTag("Border")) {
            direction.y *= -1;
        }
        speed += 0.1f;
    }
}
