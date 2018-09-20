using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour3d : MonoBehaviour {


    void Update() {
        transform.Translate(-Vector3.forward * Globals.speed, Space.World);
    }
}
