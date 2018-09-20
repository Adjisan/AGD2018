using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "projectile") {
            Debug.Log("BAM");
            Destroy(collision.gameObject);
        }
    }
}
