using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLevel : MonoBehaviour {

    public int levelToUnlock;

    void Start()
    { 
    PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }
}
