using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile3d : MonoBehaviour {

    public LayerMask clickMask;
    private Vector3 initialPos;
    public int maxPull = 10;
    public int force = 10;
    private bool shot = false;
    public int controltype = 2;
    Transform parentTransform;

    //swipe control variables
    Vector2 startPos, endPos, direction; // touch start position, touch end position, swipe direction
    float touchTimeStart, touchTimeFinish; // to calculate swipe time to sontrol throw force in Z direction

    void Start() {
        initialPos = transform.position;
        if (controltype == 3) {
            parentTransform = transform.parent;
            transform.parent = null;
        }
        
    }

    void Update() {
        switch (controltype) {
            case 0:     //drag
                DragControl();
                break;
            case 1:     //tap back
                TapBackControl();
                break;
            case 2:     //tap target
                TapTargetControl();
                break;
            case 3:     //swipe
                SwipeControl();
                break;
        }
        
    }
    public void DragControl (){
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
    public void TapBackControl () {
        if (Input.GetMouseButton(0)) {
            if (!shot) {
                PullBack();
            }
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
        transform.LookAt(initialPos);

        //force max range
        if (Vector3.Distance(initialPos, clickposition) > maxPull) {
            transform.position = initialPos + (clickposition - initialPos).normalized * maxPull;
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
            transform.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 1, 1 * force), ForceMode.Impulse);
        }
    }

    public void SwipeControl() {
        /* // if you touch the screen
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
             Debug.Log("touch");
             // getting touch position and marking time when you touch the screen
             touchTimeStart = Time.time;
             startPos = Input.GetTouch(0).position;
         }

         // if you release your finger
         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) {
             Debug.Log("dragg");
             // marking time when you release it
             touchTimeFinish = Time.time;

             // calculate swipe time interval 
             //timeInterval = touchTimeFinish - touchTimeStart;

             // getting release finger position
             endPos = Input.GetTouch(0).position;

             // calculating swipe direction in 2D space
             direction = startPos - endPos;

             // add force to balls rigidbody in 3D space depending on swipe time, direction and throw forces
             if (shot) { return; }
             shot = true;
             transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
             transform.gameObject.GetComponent<TrailRenderer>().enabled = true;
             transform.parent = parentTransform;
             transform.rotation = Quaternion.FromToRotation(-Vector3.forward, new Vector3(direction.x,0,direction.y));
             transform.gameObject.GetComponent<Rigidbody>().AddRelativeForce( new Vector3(0, 1, 1 * 100), ForceMode.Impulse);
         }*/
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


}
