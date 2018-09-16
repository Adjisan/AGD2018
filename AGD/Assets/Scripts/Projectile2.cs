using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile2 : MonoBehaviour {
    private Vector2 initialPos;
    public int maxPull = 10;
    public int force = 10;
    private bool shot = false;
	// Use this for initialization
	void Start () {
        initialPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) {
            //transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            if (!shot) {
                pullBird();
            }
        }
        if (Input.GetMouseButtonUp(0)) {
            //shoot when released
            if (shot) { return; }
            shot = true;
            transform.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            transform.gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(force * Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), initialPos), 0), ForceMode2D.Impulse);
        }
    }

    public void pullBird() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //look to the center
        transform.right = initialPos - new Vector2(transform.position.x, transform.position.y);
        
        //restrict maximum pull but move freely within the maximum pull
        if (Vector2.Distance(mousePosition, initialPos) > maxPull) {
            transform.position = initialPos + (mousePosition - initialPos).normalized * maxPull;
        } else {
            transform.position = mousePosition;
        }
    }
}
