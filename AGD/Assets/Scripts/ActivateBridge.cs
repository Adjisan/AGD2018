using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBridge : MonoBehaviour {
    public string uponCollisionWith = "projectile";
    [SerializeField]
    private AudioSource Opening;
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == uponCollisionWith) {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Animator>().enabled = true;
            Opening.Play();
        }
    }
}
