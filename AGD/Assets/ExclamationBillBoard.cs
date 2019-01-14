using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamationBillBoard : MonoBehaviour {
    void Update()
    {
        transform.LookAt(-Camera.main.transform.position, new Vector3(0,1,0));
    }
}
