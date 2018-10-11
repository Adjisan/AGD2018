using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject projectile;
    public GameObject parent;
    private void OnMouseDown() {
        GameObject obj = Instantiate(projectile, transform.position, transform.rotation);
        obj.transform.parent = gameObject.transform;
    }
}
