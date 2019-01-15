using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoHandler : MonoBehaviour {
    public int ammo;
    public bool collidesWithTrigger = false;
    public string collidesWithTag = "Player";
    public bool onlyOnce = true;
    public bool destroy = false;
    public AudioSource PlayerHitsSign;
    public AudioSource PlayerHurt;

    public GameObject loseNewspaperParticles;

    private bool triggered = false;
    private GameManagerScript gmScript;
    public GameObject textPrefab;
    private GameObject textObject;

    // Use this for initialization
    void Start () {
        gmScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        if (textPrefab != null)
        {
            textObject = Instantiate(textPrefab);
            textObject.transform.SetParent(gameObject.transform, false);
            Vector3 temp = transform.position;
            temp.y += 40;
            textObject.transform.position = temp;

           
               textObject.transform.localScale = new Vector3(0.8f,0.8f,0.8f);
               textObject.transform.Rotate(new Vector3(0,90,0),Space.World);
            
            textObject.GetComponent<TextMeshPro>().SetText( "¡" /*+ amountNeeded*/);
        }
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
            Destroy(textObject);
            HandleAmmo(other.gameObject);
        }
    }

    void HandleAmmo(GameObject other) {
        gmScript.SubtractAmmo(ammo);
        if (ammo > 0) {
            if (loseNewspaperParticles != null) {
                gmScript.ShakeScreen();
                PlayerHurt.Play();
                PlayerHitsSign.Play();
                GameObject clone = Instantiate(loseNewspaperParticles, other.transform.position, transform.rotation, null);
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