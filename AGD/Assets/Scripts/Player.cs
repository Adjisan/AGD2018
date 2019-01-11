using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public GameObject projectile;
    private void OnMouseDown() {
        if (GameObject.Find("GameManager").GetComponent<GameManagerScript>().ammo <= 0) return;
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
        GameObject obj = Instantiate(projectile, spawnPosition, transform.rotation);
        obj.transform.parent = gameObject.transform;
    }
}
