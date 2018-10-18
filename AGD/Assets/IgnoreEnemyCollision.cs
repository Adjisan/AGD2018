using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreEnemyCollision : MonoBehaviour {

    GameObject enemy;
	// Use this for initialization
	void Start () {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        Physics.IgnoreCollision(enemy.GetComponent<Collider>(), this.GetComponent<Collider>());
    }
	
}
