using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour {

    private void OnCollisionEnter(Collision collision) {
            Destroy(collision.gameObject); 
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag != "Ground" && other.gameObject.tag != "Border") {
            Destroy(other.gameObject);
        }
       
    }
}
