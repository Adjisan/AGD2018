using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
   private void OnDrawGizmos()
   {
	   Gizmos.color = Color.blue;
	   Gizmos.DrawCube(transform.position, new Vector3(10,10,10));  
   }
}
