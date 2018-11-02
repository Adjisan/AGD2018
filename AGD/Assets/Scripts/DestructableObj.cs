using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObj : MonoBehaviour {
    public bool inculdeChildren = true;

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "projectile") {
            if (!inculdeChildren) {
                transform.DetachChildren();
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
