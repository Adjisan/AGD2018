using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject projectile;

    private void OnMouseDown() {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
