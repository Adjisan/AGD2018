using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {
//adjust this to change speed
public Vector3 startPosition;
public float velocity = 0.3f;
public float upperBounds = 50f;

public float lowerBounds = 45f;
bool up=true;
// Use this for initialization
void Start () 
{
    //maxSpeed = 3;
    startPosition = transform.position;

}
// Update is called once per frame
void Update ()
{
    MoveVertical ();
}
void MoveVertical()
{   
	Debug.Log("LOLO");
    var temp=transform.position;
    print (up);
    if(up==true)
    {
        temp.y += velocity;
        transform.position=temp;
        if(transform.position.y>=upperBounds)
        {
            up = false;
        }
    }
    if(up==false)
    {
        temp.y -= velocity;
        transform.position=temp;
        if(transform.position.y<=lowerBounds)
        {
            up = true;
        }
    }
}
}
