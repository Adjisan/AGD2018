using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetsHitSound : MonoBehaviour {

    [SerializeField]
    private AudioSource playerHit;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Ground")
        {
            Debug.Log("PlayerHits");
            playerHit.Play();
        }
    }
}
