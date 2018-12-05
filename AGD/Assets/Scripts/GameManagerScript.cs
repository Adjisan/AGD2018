using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour {
    private float baseSpeed;
	public float salary;
    public TextMeshProUGUI salaryText;
    public TextMeshProUGUI multiplierText;

    private float multiplier;
    public float timesHit = 0;

    public float[] multiplierOptions;
    public float[] hitsNeeded;
    public float[] speedAdded;
    private int multiplierIndex = 0;

    public int ammo;
    public Text ammoText;
    public int Levelindex;
    //check index foir amount of hits needed
    //if  times hit == amount of hits needed level +
	// Use this for initialization
	void Start () {
		salary = 0f;
        multiplier = multiplierOptions[multiplierIndex];
        SetSalaryText();
        SetAmmoText();
        Globals.speed = Globals.baseSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        //	levelCompleteCheck();
        AmmoDepletionCheck();
	}

	public void SetSalaryText(){
        //salaryText.text = "$$ " + salary.ToString(); 
        //salaryText.GetComponent<TextMeshPro>().SetText( "$$ " + salary.ToString() );
        salaryText.SetText( "$ " + salary.ToString() );
    }
    public void AddSalary(float amount){
        salary = salary + (amount * multiplier);
        SetSalaryText();
    }
    public void SubtractSalary(float amount) {
        if ((salary - amount) >= 0) {
            salary = salary - amount;
        } else {
            salary = 0;
        }
        SetSalaryText();
    }

    public void IncreaseMultiplier() {
        if (timesHit < hitsNeeded[multiplierIndex]) {
            timesHit += 1;
        } else {
            if (multiplierIndex < (multiplierOptions.Length - 1)) {
                multiplierIndex += 1;
                Globals.speed = Globals.baseSpeed + speedAdded[multiplierIndex];
                multiplier = multiplierOptions[multiplierIndex];
                SetMultiplierText();
            }
            timesHit = 0;
        }
    }
    public void ResetMultiplier() {
        Debug.Log("ResetMultiplier");
        multiplierIndex = 0;
        multiplier = multiplierOptions[multiplierIndex];
        timesHit = 0;
        SetMultiplierText();
        Globals.speed = Globals.baseSpeed;
    }
    public void SetMultiplierText() {
        multiplierText.SetText(multiplierOptions[multiplierIndex].ToString() + "x");
    }
    public void SetAmmoText(){
        if (ammoText != null) {
            ammoText.text = /*"Newspapers left: " +*/ ammo.ToString();
        }
    }
    public void AddAmmo(int amount) {
        ammo = ammo + amount;
        SetAmmoText();
    }
    public void SubtractAmmo(int amount){
        ammo = ammo - amount;
        SetAmmoText();
    }
    public void AmmoDepletionCheck()
    {
        if(ammo <= 0)
        {
            ammoText.text = "You ran out of newspaper! :(";
            SceneManager.LoadScene("MainMenu");
        }
    }
}
