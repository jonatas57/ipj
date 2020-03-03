using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

  private static GameManager instance;

  public int leftScore;
  public int rightScore;
  public bool humanVsCpu;

  private void Awake() {
    if (instance != null) {
      DestroyImmediate(this);
      return;
    }
    instance = this;
    DontDestroyOnLoad(this);
  }

  public static GameManager Instance {
    get {
      if (instance == null) {
        instance = new GameObject("GameManager").AddComponent<GameManager>();
      }
      return instance;
    }
  }

  private void Update() {
    if (Input.GetKey(KeyCode.Escape)) {
      #if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
      #else
      Application.Quit();
      #endif
    }
  }
  
  public void ResetScore() {
    leftScore = rightScore = 0;
  }

  public bool IsGameOver() {
    return leftScore == 3 || rightScore == 3;
  }

  public void AddScore(int left, int right) {
    leftScore += left;
    rightScore += right;

    //TODO: UI Score

    if (IsGameOver()) {
      //TODO: Game Over Scene
    }
  }
}
