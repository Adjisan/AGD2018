using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	 void OnCollisionEnter(Collision other)
    {
		Debug.Log("BLOCK COL");
         if (other.gameObject.tag == "Car")
        {
            Debug.Log("BlockCar Collision");
        }
		if (other.gameObject.name == "AmmoBus")
        {
            Debug.Log("Name Col Collision");
        }
	}
}
