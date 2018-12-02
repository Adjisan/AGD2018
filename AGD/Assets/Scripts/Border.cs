using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour {
    public string[] tags;

    private void OnCollisionEnter(Collision other) {
        CollisionHandler(other.gameObject);
    }
    private void OnTriggerEnter(Collider other) {
        CollisionHandler(other.gameObject);
    }
    private void CollisionHandler(GameObject other) {
        for (int i = 0; i < tags.Length; i++) {
            if (other.tag == tags[i]) {
                if (other.GetComponent<SalaryHandler>() != null && 
                    other.GetComponent<SalaryHandler>().loseMultiplier && 
                    other.GetComponent<Target>().open) {
                    GameManagerScript gmScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
                    gmScript.ResetMultiplier();
                }
                Destroy(other);
            }
        }
    }
}
