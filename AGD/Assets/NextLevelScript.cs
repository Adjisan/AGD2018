using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelScript : MonoBehaviour {

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "PlayerDrag")
        {
        Debug.Log("LevelWOn");
        }
    }
}
