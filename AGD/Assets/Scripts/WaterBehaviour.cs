using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour {
    private bool triggered = false;
    public int LevelIndex = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision) {
        
        if (collision.transform.tag == "Player" && !triggered) {
            Debug.Log("Triggered");
            StartCoroutine(Death());
            triggered = true;
        }
    }
    IEnumerator Death() {
        yield return new WaitForSeconds(2);
        transform.GetComponent<GoToLevel>().Level(LevelIndex);

    }
}
