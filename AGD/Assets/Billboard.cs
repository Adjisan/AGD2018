using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this code was obtained at the following site: https://answers.unity.com/questions/52656/how-i-can-create-an-sprite-that-always-look-at-the.html
public class Billboard : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.main.transform.position, -Vector3.up);
    }
}
