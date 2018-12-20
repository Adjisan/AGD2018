using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundEnemy : MonoBehaviour {
    public float enemyRotation;


	// Update is called once per frame
	void Update () {
        enemyRotation = GameObject.FindGameObjectWithTag("Enemy").transform.rotation.y;
        transform.Rotate(0, enemyRotation, 0);
    }
}
