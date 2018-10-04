using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkingdog : MonoBehaviour {
    public float speed;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * ((speed + Globals.speed) * Time.deltaTime), Space.Self);
    }
}
