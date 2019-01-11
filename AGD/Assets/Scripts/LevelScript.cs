using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour {

public int levelIndex;
public GameManagerScript gmScript;

	// Use this for initialization
	void Start () {
		gmScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
	}

	private void OnCollisionEnter(Collision other)
	{
			Debug.Log(other.transform.tag);
		if(other.transform.tag == "Player")
		{
			gmScript.Levelindex = levelIndex;
			Debug.Log("Level indexed changed to " + levelIndex);
			Destroy(this.gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
