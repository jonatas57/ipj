using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongArea : MonoBehaviour {
  GameObject leftPaddle;
  GameObject rightPaddle;
  GameObject ball;
  Rigidbody2D ballRigidBody;

  private void Start() {
    leftPaddle = transform.Find("LeftPaddle").gameObject;
    rightPaddle = transform.Find("RightPaddle").gameObject;
    ball = transform.Find("Ball").gameObject;
    ballRigidBody = ball.GetComponent<Rigidbody2D>();
  }

  private void ResetArea() {
    ball.GetComponent<BallController>().ResetBall();
    leftPaddle.GetComponent<PaddleController>().ResetPosition();
    rightPaddle.GetComponent<PaddleController>().ResetPosition();
  }

  private void LateUpdate() {
    if (ball.transform.localPosition.x < -1.3f) {
      GameManager.Instance.AddScore(0, 1);
      if (!GameManager.Instance.IsGameOver()) ResetArea();
    }
    else if (ball.transform.localPosition.x > 1.3f) {
      GameManager.Instance.AddScore(1, 0);
      if (!GameManager.Instance.IsGameOver()) ResetArea();
    }
  }
}
