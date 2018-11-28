using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {
	private int scoreCount;
    public Text scoreCountText;
	public int maxScoreCount;

    public int ammo;
    public Text ammoText;
    public int noAmmoCount;
    public int Levelindex;

	// Use this for initialization
	void Start () {
		scoreCount = 0;
        setScoreCountText();
        ammoCountText();
	}
	
	// Update is called once per frame
	void Update () {
	//	levelCompleteCheck();
        onAmmoDepletionCheck();
	}

	public void setScoreCountText(){
     //   scoreCountText.text = scoreCount.ToString() + "/" +  maxScoreCount; 
    }
    public void incrementScore(int score){
        scoreCount = scoreCount += score;
    }

    public void ammoCountText()
    {
        ammoText.text = /*"Newspapers left: " +*/ ammo.ToString();
    }
    public void DepleteAmmo(int decreaseAmmo)
    {
        ammo = ammo -= decreaseAmmo;
    }
	// check win condition
	/*public void levelCompleteCheck(){
		if(scoreCount == maxScoreCount){
			scoreCountText.text = "You Win!";
		}
	}*/

    public void onAmmoDepletionCheck()
    {
        if(ammo == noAmmoCount)
        {
            ammoText.text = "You ran out of newspaper! :(";
            SceneManager.LoadScene("MainMenu");
        }
    }
}
