using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour {
	public float salary;
    public TextMeshProUGUI salaryText;

    private float multiplier;
    public float[] multiplierOptions = {1,2,3,4,5};
    private int multiplierIndex = 0;

    public int ammo;
    public Text ammoText;
    public int Levelindex;

	// Use this for initialization
	void Start () {
		salary = 0f;
        multiplier = multiplierOptions[multiplierIndex];
        SetSalaryText();
        SetAmmoText();
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
        if (multiplierIndex < (multiplierOptions.Length - 1)){
            multiplierIndex += 1;
            multiplier = multiplierOptions[multiplierIndex];
        }
    }
    public void ResetMultiplier() {
        multiplierIndex = 0;
        multiplier = multiplierOptions[multiplierIndex];
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
            SceneManager.LoadScene(Levelindex);
        }
    }
}
