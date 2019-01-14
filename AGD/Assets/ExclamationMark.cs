using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ExclamationMark : MonoBehaviour
{
    public bool open = true;
    public GameObject textPrefab;
    private GameObject textObject;
    public bool left = true;
    string[] sayings = { "PAWsome", "PAWmazing", "RAWRsome", "FURtastic", "FURbulous", "BEARilliant", "FURrific" };

    // Use this for initialization
    void Start()
    {
        if (textPrefab != null)
        {
            textObject = Instantiate(textPrefab);
            textObject.transform.SetParent(gameObject.transform, false);
            textObject.GetComponent<TextMeshPro>().SetText("!" /*+ amountNeeded*/);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "projectile" && open)
        {
            textObject.GetComponent<TextMeshPro>().SetText(sayings.RandomItem() /*+ amountNeeded*/);;
            open = false;
            textObject.transform.SetParent(null);
            textObject.transform.localScale = new Vector3(1, 1, 1);
            textObject.GetComponent<Animator>().enabled = true;
        }
    }
}
