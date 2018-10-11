using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour {

    public int ammo = 30;
    public Text uitext;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(uitext != null)
        {
            uitext.text = "Ammo left: " + ammo.ToString();
        }
	}
}
