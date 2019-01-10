using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour {

    [Range(0f,2f)]
    public float intensity;
    Transform target;
    Vector3 initialPos;

    float pendingShakeDuration = 0f;
    bool isShaking = false;
	// Use this for initialization
	void Start () {
        target = GetComponent<Transform>();
        initialPos = transform.localPosition;
	}

    public void Shake(float duration) {
        if (duration > 0) {
            pendingShakeDuration += duration;
        }
    }

    private void Update() {
        if (pendingShakeDuration >0 && !isShaking) {
            StartCoroutine(DoShake());
        }
    }
    IEnumerator DoShake() {
        isShaking = true;

        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + pendingShakeDuration) {
            Vector3 randomPoint = new Vector3(
                initialPos.x + (Random.Range(-1, 1) * intensity), 
                initialPos.y + (Random.Range(-1, 1) * intensity), 
                initialPos.z + (Random.Range(-1, 1) * intensity));
            target.localPosition = randomPoint;
            yield return null;
        }
        pendingShakeDuration = 0;
        target.localPosition = initialPos;
        isShaking = false;
    }
}
