using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHandler : MonoBehaviour {

    public LayerMask clickMask;
    public int maxPull = 10;
    public int force = 10;
    public bool demoProjectile = false;
    public bool tap = false;

    private bool shot = false;
    Transform parentTransform;
    Rigidbody rigBody;

    void Start() {
        rigBody = transform.gameObject.GetComponent<Rigidbody>();
        parentTransform = gameObject.transform.parent;

        if (demoProjectile) {
            DemoBehaviour();
        }
    }

    void Update() {
        if (tap) {
            TapTargetControl();
        } else {
            DragControl();
        }
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
        rigBody.isKinematic = false;
        transform.gameObject.GetComponent<TrailRenderer>().enabled = true;
        rigBody.AddRelativeForce(new Vector3(0, 1, (1 * (force * Vector3.Distance(transform.position, parentTransform.position))) * Globals.speed/50), ForceMode.Impulse);
        rigBody.AddTorque(new Vector3 (0, Random.Range(-1440f, 1440f), 0), ForceMode.Impulse);
        transform.parent = null;

        AmmoHandler();
    }
    public void PullBack() {
        Vector3 clickposition = -Vector3.one;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //check position on (whatever layermask is checked)
        if (Physics.Raycast(ray, out hit, 1000f, clickMask)) {
            clickposition = hit.point;
            clickposition.y = 2;
            transform.position = clickposition;
        }

        //look to the center
        parentTransform.position = new Vector3(parentTransform.position.x, clickposition.y, parentTransform.position.z);
        transform.LookAt(parentTransform);

        //force max range
        if (Vector3.Distance(parentTransform.position, clickposition) > maxPull) {
            transform.position = parentTransform.position + (clickposition - parentTransform.position).normalized * maxPull;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        //Explode();
        //Destroy(collision.gameObject);
        rigBody.constraints = RigidbodyConstraints.None;
        StartCoroutine(SlowTrailDisable());
    }

    IEnumerator SlowTrailDisable() {
        TrailRenderer trail = transform.gameObject.GetComponent<TrailRenderer>();
        float rate = trail.time / 15f;
        while (trail.time > 0) {
            trail.time -= rate;
            yield return 0;
        }
        //Destroy(gameObject);
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
            rigBody.isKinematic = false;
            transform.gameObject.GetComponent<TrailRenderer>().enabled = true;
            rigBody.AddRelativeForce(new Vector3(0, 1, (1 * (force * 10)) * Globals.speed / 50), ForceMode.Impulse);
            transform.parent = null;
        }
    }
    void Explode() {
        Debug.Log("Boom");
        float radius = 10f;
        float explosionForce = 5000f;
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders) {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null) {
                rb.AddExplosionForce(explosionForce, transform.position, radius, 10);
            }
        }
    }

    void DemoBehaviour() {
       
        shot = true;
        rigBody.isKinematic = false;
        transform.gameObject.GetComponent<TrailRenderer>().enabled = true;
        rigBody.AddRelativeForce(new Vector3(0, 1, (1 * (force * 10)) * Globals.speed / 50), ForceMode.Impulse);
        rigBody.AddTorque(new Vector3(0, Random.Range(-1440f, 1440f), 0), ForceMode.Impulse);
        transform.parent = null;
    }

    void AmmoHandler() {
        if (GameObject.Find("GameManager") != null) {
            GameManagerScript gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

            gameManager.DepleteAmmo(1);
            gameManager.ammoCountText();
        }
    }
}
