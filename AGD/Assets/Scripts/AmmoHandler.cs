using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHandler : MonoBehaviour {
    public int ammo;
    public bool collidesWithTrigger = false;
    public string collidesWithTag = "Player";
    public bool onlyOnce = true;
    public bool destroy = false;

    public GameObject loseNewspaperParticles;

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
            HandleAmmo(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision other) {
        if (collidesWithTrigger)
            return;
        if (other.transform.tag == collidesWithTag && !triggered) {
            HandleAmmo(other.gameObject);
        }
    }

    void HandleAmmo(GameObject other) {
        gmScript.SubtractAmmo(ammo);
        if (ammo > 0) {
            if (loseNewspaperParticles != null) {
                Instantiate(loseNewspaperParticles, other.transform.position, transform.rotation, null);
            }
        }
        if (onlyOnce) {
            triggered = true;
        }
        if (destroy) {
            Destroy(other);
        }
    }
}