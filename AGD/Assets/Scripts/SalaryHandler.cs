using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SalaryHandler : MonoBehaviour {
    public GameObject coinObj;
    public float SalaryAmount;
    public bool increase = true;
    private GameManagerScript gmScript;

    public bool collidesWithTrigger = false;
    public string collidesWithTag = "projectile";
    public bool onlyOnce = true;
    private bool triggered = false;
    public bool isMultiplierObject = false;
    public bool loseMultiplier = false;

    // Use this for initialization
    void Start () {
        gmScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void HandleSalary() {
        if (increase) {
            gmScript.AddSalary(SalaryAmount);
            for (int i = 0; i < SalaryAmount*gmScript.GetMultiplier(); i++) {
                SpawnCoin();
            }
        } else {
            gmScript.SubtractSalary(SalaryAmount);
        }
        if (isMultiplierObject) {
            gmScript.IncreaseMultiplier();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!collidesWithTrigger)
            return;
        if (other.transform.tag == collidesWithTag && !triggered) {
            triggered = true;
            HandleSalary();
        }
        CheckDestroy(other.gameObject);
    }
    private void OnTriggerExit(Collider other) {
        if (!onlyOnce) {
            triggered = false;
        }
    }
    private void OnCollisionEnter(Collision other) {
        if (collidesWithTrigger)
            return;
        if (other.transform.tag == collidesWithTag && !triggered) {
            triggered = true;
            HandleSalary();
        }
        CheckDestroy(other.gameObject);
    }
    private void OnCollisionExit(Collision collision) {
        if (!onlyOnce) {
            triggered = false;
        }
    }
    private void CheckDestroy(GameObject other) {
        if (!other && !onlyOnce) {
            triggered = false;
        }
    }
    private void SpawnCoin() {
        GameObject coin = Instantiate(coinObj);
        coin.transform.position = transform.position;
    }
}
