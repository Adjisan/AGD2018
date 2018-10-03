using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public int levelModifier = 0;
    public Button[] levelButtons;

	// Use this for initialization
	void Start ()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 0);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
            if (i < levelReached)
            {
                levelButtons[i].interactable = true;
            }
        }	
	}

}
//this was created using the following tutorial: https://www.youtube.com/watch?v=AQpDtrNJAEU