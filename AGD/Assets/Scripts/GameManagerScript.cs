using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {
	private int scoreCount;
    public Text scoreCountText;
	public int maxScoreCount;
	// Use this for initialization
	void Start () {
		scoreCount = 0;
        setScoreCountText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void setScoreCountText(){
        scoreCountText.text = scoreCount.ToString() + "/" +  maxScoreCount; 
    }
    public void incrementScore(int score){
        scoreCount = scoreCount += score;
    }
}
