using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SalarySetText : MonoBehaviour
{
    public TextMeshProUGUI salaryText;
    public FloatVariable salary;
    public IntVariable multiplier;


    public void Start()
    {
        salary.Value = 0f;
        SetSalaryText();
    }
    public void SetSalaryText()
    {
       salaryText.SetText("$ " + salary.ToString());
    }
    public void AddSalary(float amount)
    {
        salary.Value = salary.Value + (amount * multiplier.Value);
        SetSalaryText();
    }
    public void SubtractSalary(float amount)
    {
        if ((salary.Value - amount) >= 0)
        {
            salary.Value = salary.Value - amount;
        }
        else
        {
            salary.Value = 0;
        }
        SetSalaryText();
    }
}
