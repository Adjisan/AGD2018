using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingHandler : MonoBehaviour {
    Transform parentTransform;
    bool triggered = false;
    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "Bridge" && !triggered) {
            parentTransform = transform.parent;

            Transform bear = transform.Find("Bear");
            bear.parent = null;
            transform.parent = null;
            transform.GetComponent<Rigidbody>().isKinematic = false;
            bear.GetComponent<Rigidbody>().isKinematic = false;

            gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*600, ForceMode.Impulse);
            bear.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*200,ForceMode.Impulse);
            StartCoroutine(DisableMovement());
            triggered = true;
        }
    }
    IEnumerator DisableMovement() {
        yield return new WaitForSeconds(2);
        parentTransform.GetComponent<TargetBehaviour3d>().enabled = false;
    }
}
