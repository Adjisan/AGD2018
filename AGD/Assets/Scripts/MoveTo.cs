using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour {
    public Transform goal;
    [Range(1f, 10f)]
    public float Speed = 1.0f;
    private float closeEnough = 10;
    public float randomRadius;
    bool finalStep = false;

    private Vector3 targetPosition;
    private Vector3 currentPosition;
    private RectTransform objTrans;
    private float distanceToTarget;


    // Use this for initialization
    void Start() {
        goal = GameObject.Find("SalaryText").transform;
        objTrans = GetComponent<RectTransform>();
        objTrans.position = Camera.main.WorldToScreenPoint(transform.position);
        transform.SetParent(goal);
        //Get its current position
        currentPosition = objTrans.anchoredPosition;

        //Get a reference to where we want it to go
        //targetPosition = goal.GetComponent<RectTransform>().anchoredPosition;
        targetPosition = objTrans.anchoredPosition + (Random.insideUnitCircle * randomRadius);
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void LateUpdate() {
        if (distanceToTarget < closeEnough) {
            if (!finalStep) {
                targetPosition = goal.GetComponent<RectTransform>().anchoredPosition;
                finalStep = true;
            } else {
                Destroy(gameObject);
            }
        }
    }
    void Move() {
        //Get a position that is a little bit closer to our goal position
        objTrans.anchoredPosition = Vector3.Lerp(currentPosition, targetPosition, Speed * Time.deltaTime);

        //Set our object to that new position
        currentPosition = objTrans.anchoredPosition;

        //How far are we from our goal?
        distanceToTarget = Vector3.Distance(currentPosition, targetPosition);
    }
}
