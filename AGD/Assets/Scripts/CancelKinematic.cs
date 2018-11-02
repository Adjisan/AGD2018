using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelKinematic : MonoBehaviour {
    public string uponCollisionWith = "projectile";
    public bool impulse = true;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == uponCollisionWith) {
            GetComponent<Rigidbody>().isKinematic = false;
            if (impulse) {
                GetComponent<Rigidbody>().AddRelativeForce(collision.relativeVelocity, ForceMode.VelocityChange);
            } else {
                GetComponent<Rigidbody>().AddRelativeForce(collision.relativeVelocity, ForceMode.Force);
            }
        }
    }
}
