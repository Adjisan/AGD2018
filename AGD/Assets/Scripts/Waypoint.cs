using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
    public Color gizmoColor;
   private void OnDrawGizmos()
   {   
       Gizmos.color = gizmoColor;
       Gizmos.DrawCube(transform.position, new Vector3(10,10,10));
   }
   public void colorGizmo(Color newColor){
       gizmoColor = newColor;
       OnDrawGizmos();
   }
}
