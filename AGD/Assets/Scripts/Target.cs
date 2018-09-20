using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public bool open = true;
    public string closeAnimationTrigger;
    public int amountNeeded = 1;

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "projectile" && open) {
            
            amountNeeded--;
            if (amountNeeded <= 1) {
                open = false;
                triggerAnimation();
            }
            Destroy(collision.gameObject);
        }
    }
    public void triggerAnimation() {
        if (gameObject.GetComponent<Animator>() != null) {
            gameObject.GetComponent<Animator>().SetTrigger(closeAnimationTrigger);
        }
        
    }
}
