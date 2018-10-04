using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelScript : MonoBehaviour {

    public int levelToUnlock;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "playerObj")
        {
            Debug.Log("LevelReached: " + levelToUnlock);
            PlayerPrefs.SetInt("levelReached", levelToUnlock);
        }
    }
}
