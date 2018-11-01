using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelKinematic : MonoBehaviour {
    public string uponCollisionWith = "projectile";
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == uponCollisionWith) {
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddRelativeForce(collision.relativeVelocity,ForceMode.VelocityChange);
        }
    }
}
