using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNet : MonoBehaviour {

  public Transform dotPrefab;
  public int numberDots;

  // Start is called before the first frame update
  void Start() {
    float stepSize = 2 * Camera.main.orthographicSize / numberDots;
    float y = -1f;
    for (int i = 0;i < numberDots;i++, y += stepSize) {
      Transform dotInstance = Instantiate<Transform>(dotPrefab);
      dotInstance.name = "dot" + i;
      dotInstance.parent = transform;
      dotInstance.position = new Vector3(0, y, 0);
    }
  }
}
