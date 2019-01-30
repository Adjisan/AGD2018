using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MultiplierSetText : MonoBehaviour {

    public TextMeshProUGUI multiplierText;
    private Vector3 baseSizeMultiplier;

    private int multiplierIndex = 0;
    private float multiplier;

    public float[] speedAdded;
    public float[] hitsNeeded;
    public float[] multiplierOptions;

    public float timesHit = 0;

    // Use this for initialization
    void Start () {
        baseSizeMultiplier = multiplierText.GetComponent<RectTransform>().localScale;
        multiplier = multiplierOptions[multiplierIndex];
    }
    public void SetMultiplierText()
    {
        multiplierText.SetText(multiplierOptions[multiplierIndex].ToString() + "x");
        float size = (0.05f) * ((100 / multiplierOptions.Length) * (multiplierIndex + 1));
        size += 1;
        multiplierText.GetComponent<RectTransform>().localScale = baseSizeMultiplier * size;

    }
    public float GetMultiplier()
    {
        return multiplier;
    }
    public void IncreaseMultiplier()
    {
        if (timesHit < hitsNeeded[multiplierIndex])
        {
            timesHit += 1;
        }
        else
        {
            if (multiplierIndex < (multiplierOptions.Length - 1))
            {
                multiplierIndex += 1;
                Globals.speed = Globals.baseSpeed + speedAdded[multiplierIndex];
                multiplier = multiplierOptions[multiplierIndex];
                SetMultiplierText();
            }
            timesHit = 0;
        }
    }
    public void ResetMultiplier()
    {
        //Debug.Log("ResetMultiplier");
        multiplierIndex = (int)((float)multiplierIndex / 1.25f);
        multiplier = multiplierOptions[multiplierIndex];
        timesHit = 0;
        SetMultiplierText();
        Globals.speed = Globals.baseSpeed + speedAdded[multiplierIndex];
    }
}
