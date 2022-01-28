using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 mouse_pos; 
 //Transform target ; //Assign to the object you want to rotate
 Vector3 object_pos ;
  float angle ;
    public float offset;
    // Update is called once per frame
    void Update()
    {
      var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
      var angle = Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg;
      transform.rotation = Quaternion.AngleAxis(angle+offset,new Vector3(0,0,1) );
    }
}
