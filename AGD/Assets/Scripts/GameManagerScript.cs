using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

    private float baseSpeed;
    GameObject camera;
    public bool gameHasEnded = false;

    //check index fair amount of hits needed
    //if  times hit == amount of hits needed Multiplier level +
	// Use this for initialization
	void Start () {
        Globals.speed = Globals.baseSpeed;
        camera = GameObject.Find("Main Camera");
    }
	
    public void ShakeScreen() {
        camera.GetComponent<Shaker>().Shake(.1f);
    }
    
    public void CallMenu()
    {
        if (gameHasEnded)
        {
            GameObject.Find("GUI_End").transform.GetChild(0).gameObject.SetActive(true);
        }
        else {
            GameObject.Find("GUI_Pause").transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}
