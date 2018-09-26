using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour3d : MonoBehaviour {
    public bool foreward;

    void Update() {
        if (foreward) {
            transform.Translate(Vector3.forward * Globals.speed, Space.World);
        } else {
            transform.Translate(-Vector3.forward * Globals.speed, Space.World);
        }
        
    }
}
