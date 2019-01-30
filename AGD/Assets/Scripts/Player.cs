using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour {
    public GameObject projectile;
    public GameObject textPrefab;
    private GameObject countDownClone;
    private SetAmmoText ammoManager;
    [SerializeField]
    private AudioSource ThrowPaper;
    [SerializeField]
    private AudioSource CountDownAlarm;
    public int maxCountDown = 5;
    private int lastAmmo;

    private void Start()
    {
        countDownClone = Instantiate(textPrefab,transform);
    }
    private void OnMouseDown() {
        if (ammoManager.ammo <= 0) return;
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
        GameObject obj = Instantiate(projectile, spawnPosition, transform.rotation);
        obj.transform.parent = gameObject.transform;
    }

    private void Update() {
        CheckAmmo();
    }
    void CheckAmmo() {
        if (lastAmmo == ammoManager.ammo) {
            return;
        }
        print("CheckAmmo");
        if (ammoManager.ammo > maxCountDown) {
            countDownClone.SetActive(false);
            lastAmmo = ammoManager.ammo;
            ThrowPaper.Play();
        } else {
            countDownClone.SetActive(true);
            CountDownAlarm.Play();
            if (ammoManager.ammo <= 0) {
                countDownClone.GetComponent<TextMeshPro>().SetText("Empty!");
                countDownClone.transform.localScale = textPrefab.transform.localScale / 2;
            } else {
                countDownClone.GetComponent<TextMeshPro>().SetText("" + gmScript.ammo);
                countDownClone.transform.localScale = textPrefab.transform.localScale;
            }
            lastAmmo = ammoManager.ammo;
        }
    }
}
