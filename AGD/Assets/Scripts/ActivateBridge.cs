using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivateBridge : MonoBehaviour {
    public string uponCollisionWith = "projectile";
    [SerializeField]
    private AudioSource Opening;

    public GameObject textPrefab;
    private GameObject textObject;

    void Start()
    {
           if (textPrefab != null)
        {
            textObject = Instantiate(textPrefab);
            textObject.transform.SetParent(gameObject.transform, false);
            Vector3 temp = this.transform.Find("Pole").transform.Find("Base").transform.Find("Mid").transform.position;
            temp.y += 40;
            textObject.transform.position = temp;

           
               textObject.transform.localScale = new Vector3(2f,2f,2f);
               textObject.transform.Rotate(new Vector3(0,90,0),Space.World);
            
            textObject.GetComponent<TextMeshPro>().SetText( "¡" /*+ amountNeeded*/);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == uponCollisionWith) {
            Destroy(textObject);
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Animator>().enabled = true;
            Opening.Play();
        }
    }
}
