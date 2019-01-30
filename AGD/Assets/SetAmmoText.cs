using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetAmmoText : MonoBehaviour
{
    public int ammo;
    public TextMeshProUGUI ammoText;
    public GameManagerScript GM;
    public bool ExampleRunning = false;

    private void Start()
    {
        SetText();
    }

    public void SetText()
    {
        if (ammoText != null)
        {
            ammoText.text = /*"Newspapers left: " +*/ ammo.ToString();
        }
    }
    public void AddAmmo(int amount)
    {
        ammo = ammo + amount;
        SetText();
    }
    public void SubtractAmmo(int amount)
    {
        ammo = ammo - amount;
        SetText();
    }
    // Update is called once per frame
    void Update()
    {
        //	levelCompleteCheck();
        AmmoDepletionCheck();
    }

    public void AmmoDepletionCheck()
    {
        if (ammo <= 0 && !ExampleRunning)
        {
            ammoText.text = "You ran out of newspaper! :(";
            Time.timeScale = 0;
            StartCoroutine(Example());
        }
        else
        {
            Time.timeScale = 1;
        }
    }
     IEnumerator Example()
    {
        ExampleRunning = true;
        yield return new WaitForSeconds(3);
        if (ammo <= 0)
        {
            //SceneManager.LoadScene("MainMenu");
            if (GameObject.Find("GUI_End"))
            {
                GameObject.Find("GUI_End").transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        ExampleRunning = false;
    }

}
