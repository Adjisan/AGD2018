using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderHandler : MonoBehaviour {
    public string parentGameObjectName = "Player";
    public string targetPositionName = "Bike";

    void Start () {
        transform.position = GameObject.Find(targetPositionName).transform.position;
        transform.SetParent(GameObject.Find(parentGameObjectName).transform);
	}
}
