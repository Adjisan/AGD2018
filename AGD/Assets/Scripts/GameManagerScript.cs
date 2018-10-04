using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
	private int scoreCount;
    public Text scoreCountText;
	public int maxScoreCount;
    public int ammo = 30;
    public Text ammoText;

	// Use this for initialization
	void Start () {
		scoreCount = 0;
        setScoreCountText();
        ammoCountText();
	}
	
	// Update is called once per frame
	void Update () {
		levelCompleteCheck();
	}

    public void ammoCountText()
    {
        ammoText.text = ammo.ToString();
    }

	public void setScoreCountText(){
        scoreCountText.text = scoreCount.ToString() + "/" +  maxScoreCount; 
    }
    public void incrementScore(int score){
        scoreCount = scoreCount += score;
    }
	// check win condition
	public void levelCompleteCheck(){
		if(scoreCount == maxScoreCount){
			scoreCountText.text = "You Win!";
		}
	}
}
