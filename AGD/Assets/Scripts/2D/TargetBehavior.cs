using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour {
    public float speed;
    public Sprite sprite;
    public GameObject particles;
    private bool hit = false;
    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.down * Globals.speed, Space.World);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "projectile") {
            hit = true;
            //Destroy(gameObject);
            Instantiate(particles, new Vector3(transform.position.x, transform.position.y-2, transform.position.z),transform.rotation);
            Destroy(collision.gameObject);
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        }
        if (collision.gameObject.tag == "Border") {
            Debug.Log("Heya");
            if (!hit) {
                Globals.lives -= 1;
            }
            Destroy(transform.gameObject);
        }
            //TODO
            //SCORE MECHANICS
        }
}
