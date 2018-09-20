using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile3d : MonoBehaviour {
    public LayerMask clickMask;
    private Vector3 initialPos;
    public int maxPull = 10;
    public int force = 10;
    private bool shot = false;

    void Start() {
        initialPos = transform.position;
    }

    void Update() {
        if (Input.GetMouseButton(0)) {
            if (!shot) {
                pullBack();
            }
        }
        if (Input.GetMouseButtonUp(0)) {
            //shoot when released
            if (shot) { return; }
            Release();
        }
    }

    public void Release() {
        shot = true;
        transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        transform.gameObject.GetComponent<TrailRenderer>().enabled = true;
        transform.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 1, 1 * (force * Vector3.Distance(transform.position, initialPos))), ForceMode.Impulse);
        
    }

    public void pullBack() {
        Vector3 clickposition = -Vector3.one;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //check position on (whatever layermask is checked)
        if (Physics.Raycast(ray, out hit, 1000f, clickMask)) {
            clickposition = hit.point;
            clickposition.y = 0;
            transform.position = clickposition;
        }

        //look to the center
        transform.LookAt(initialPos);

        //force max range
        if (Vector3.Distance(initialPos, clickposition) > maxPull) {
            transform.position = initialPos + (clickposition - initialPos).normalized * maxPull;
        }
    }
    private void OnCollisionEnter(Collision collision) {
        transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        StartCoroutine(SlowTrailDisable());
        if (collision.transform.tag == "projectile") { return; }
        transform.parent = collision.transform.parent;
    }

    IEnumerator SlowTrailDisable() {
        TrailRenderer trail = transform.gameObject.GetComponent<TrailRenderer>();
        float rate = trail.time / 15f;
        while (trail.time > 0) {
            trail.time -= rate;
            yield return 0;
        }
    }
}
