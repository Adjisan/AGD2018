using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour {
    public GameObject projectile;
    public GameObject textPrefab;
    private GameObject countDownClone;
    private GameManagerScript gmScript;
    public int maxCountDown = 5;
    private int lastAmmo;
    private void Start() {
        countDownClone = Instantiate(textPrefab,transform);
        gmScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }
    private void OnMouseDown() {
        if (GameObject.Find("GameManager").GetComponent<GameManagerScript>().ammo <= 0) return;
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
        GameObject obj = Instantiate(projectile, spawnPosition, transform.rotation);
        obj.transform.parent = gameObject.transform;
    }

    private void Update() {
        CheckAmmo();
    }
    void CheckAmmo() {
        if (lastAmmo == gmScript.ammo) {
            return;
        }
        print("CheckAmmo");
        if (gmScript.ammo > maxCountDown) {
            countDownClone.SetActive(false);
            lastAmmo = gmScript.ammo;
        } else {
            countDownClone.SetActive(true);
            if (gmScript.ammo <= 0) {
                countDownClone.GetComponent<TextMeshPro>().SetText("Empty!");
                countDownClone.transform.localScale = textPrefab.transform.localScale / 2;
            } else {
                countDownClone.GetComponent<TextMeshPro>().SetText("" + gmScript.ammo);
                countDownClone.transform.localScale = textPrefab.transform.localScale;
            }
            lastAmmo = gmScript.ammo;
        }
    }
}
