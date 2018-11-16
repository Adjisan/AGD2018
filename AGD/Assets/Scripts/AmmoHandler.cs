using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHandler : MonoBehaviour {
    public int ammo;
    public bool collidesWithTrigger = false;
    public string collidesWithTag = "Player";
    public bool onlyOnce = true;
    public bool destroy = false;

    private bool triggered = false;
    private GameManagerScript gmScript;

    // Use this for initialization
    void Start () {
        gmScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay(Collider other) {
        if (!collidesWithTrigger)
            return;
        if (other.transform.tag == collidesWithTag && !triggered) {
            gmScript.DepleteAmmo(ammo);
            gmScript.ammoCountText();
            if (onlyOnce) {
                triggered = true;
            }
            if (destroy) {
                Destroy(other.gameObject);
            }
        }
    }
    private void OnCollisionEnter(Collision other) {
        if (collidesWithTrigger)
            return;
        if (other.transform.tag == collidesWithTag && !triggered) {
            gmScript.DepleteAmmo(ammo);
            gmScript.ammoCountText();
            if (onlyOnce) {
                triggered = true;
            }
            if (destroy) {
                Destroy(other.gameObject);
            }
        }
    }
}