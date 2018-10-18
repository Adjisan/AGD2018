using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour {

    public LayerMask clickMask;
    public int maxPull = 10;
    public int force = 10;
    public bool demoProjectile = false;
    public GameObject GameManager;

    private bool shot = false;
    Transform parentTransform;

    void Start() {
        parentTransform = gameObject.transform.parent;
        if (demoProjectile) {
            shot = true;
            transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            transform.gameObject.GetComponent<TrailRenderer>().enabled = true;
            transform.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 1, (1 * (force * 10)) * Globals.speed / 50), ForceMode.Impulse);
            transform.parent = null;
        
        }
    }

    void Update() {
        DragControl();
        //TapTargetControl();
    }
    
    public void DragControl() {
        if (Input.GetMouseButton(0)) {
            if (!shot) {
                PullBack();
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
        transform.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 1, (1 * (force * Vector3.Distance(transform.position, parentTransform.position))) * Globals.speed/50), ForceMode.Impulse);
        transform.parent = null;

        GameManager = GameObject.Find("GameManager");
        GameManager.GetComponent<GameManagerScript>().DepleteAmmo(1);
        GameManager.GetComponent<GameManagerScript>().ammoCountText();
    }
    public void PullBack() {
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
        transform.LookAt(parentTransform);

        //force max range
        if (Vector3.Distance(parentTransform.position, clickposition) > maxPull) {
            transform.position = parentTransform.position + (clickposition - parentTransform.position).normalized * maxPull;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        transform.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        StartCoroutine(SlowTrailDisable());
    }

    IEnumerator SlowTrailDisable() {
        TrailRenderer trail = transform.gameObject.GetComponent<TrailRenderer>();
        float rate = trail.time / 15f;
        while (trail.time > 0) {
            trail.time -= rate;
            yield return 0;
        }
    }
    
    public void TapTargetControl() {
        if (Input.GetMouseButton(0)) {
            if (!shot) {
                Vector3 clickposition = -Vector3.one;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                //check position on (whatever layermask is checked)
                if (Physics.Raycast(ray, out hit, 1000f, clickMask)) {
                    clickposition = hit.point;
                    clickposition.y = 0;
                    transform.LookAt(clickposition);
                }
            }
            if (shot) { return; }
            shot = true;
            transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            transform.gameObject.GetComponent<TrailRenderer>().enabled = true;
            transform.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 1, (1 * (force * 10)) * Globals.speed / 50), ForceMode.Impulse);
            transform.parent = null;
        }
    }

}
