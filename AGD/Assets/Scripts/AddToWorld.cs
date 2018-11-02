using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToWorld : MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag != "Ground") {
            transform.parent = null;
        }
    }
}
