using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour {
    public bool open = true;
    public string closeAnimationTrigger;
    public int amountNeeded = 1;
    public GameObject textPrefab;
    public bool left = true;
    private GameObject textObject;

    private void Start() {
        if (textPrefab != null) {
            textObject = Instantiate(textPrefab);
            textObject.transform.SetParent(gameObject.transform, false);

            if (!left) {
                textObject.transform.localScale = new Vector3(0.5f,0.5f,0.5f);
                textObject.transform.Rotate(new Vector3(0,180,0),Space.World);
            }
            textObject.GetComponent<TextMeshPro>().SetText( "" + amountNeeded);
        }
    }

    private GameObject gameManager;
    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "projectile" && open) {
            
            amountNeeded--;
            textObject.GetComponent<TextMeshPro>().SetText("" + amountNeeded);
            updateScore();
            if (amountNeeded < 1) {
                open = false;
                triggerAnimation();
                textObject.transform.SetParent(null);
                textObject.transform.localScale = new Vector3(1, 1, 1);
                textObject.GetComponent<Animator>().enabled = true;
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
    public void updateScore(){
        gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<GameManagerScript>().incrementScore(1);
        gameManager.GetComponent<GameManagerScript>().setScoreCountText();
    }
}
