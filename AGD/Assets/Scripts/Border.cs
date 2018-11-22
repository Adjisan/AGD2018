using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour {
    public string[] tags;
    private void OnCollisionEnter(Collision other) {
        for (int i = 0; i < tags.Length; i++) {
            if (other.gameObject.tag == tags[i]) {
                Destroy(other.gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        for (int i = 0; i < tags.Length; i++) {
            if (other.gameObject.tag == tags[i]) {
                Destroy(other.gameObject);
            }
        }
    }
}
