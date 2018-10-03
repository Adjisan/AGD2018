﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public Button[] levelButtons;

	// Use this for initialization
	void Start ()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                Debug.Log(levelReached);
                levelButtons[i].interactable = false;
            }
        }	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
//this was created using the following tutorial: https://www.youtube.com/watch?v=AQpDtrNJAEU