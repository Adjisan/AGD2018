using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorHandler : MonoBehaviour {
    public LayerMask clickMask;
    private GameManagerScript gmScript;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gmScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && gmScript.ammo > 0) {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            Vector3 clickposition = -Vector3.one;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //check position on (whatever layermask is checked)
            if (Physics.Raycast(ray, out hit, 1000f, clickMask)) {
                clickposition = hit.point;
                clickposition.y = transform.position.y;
                //transform.position = clickposition;
                transform.LookAt(clickposition);
            }
            float scale = Vector3.Distance(transform.position, clickposition) / 10;
            if (scale > 2) {
                scale = 2;
            }
            transform.localScale = new Vector3(scale, scale, scale*2);
        } else {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
