using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointHandler : MonoBehaviour {

    RectTransform objTrans;
    public string parentName = "GUI";
    public string playerName = "Player";
    // Use this for initialization
    void Start () {
        transform.position = GameObject.Find(playerName).transform.position;
        transform.parent = GameObject.Find(parentName).transform;
        objTrans = GetComponent<RectTransform>();
        objTrans.position = Camera.main.WorldToScreenPoint(transform.position);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
