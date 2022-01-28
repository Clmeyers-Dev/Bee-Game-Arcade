using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
 
    Vector3 mouse_pos; 
 
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
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");
        if(other.tag == "collision"){
            //TODO  create an explosion on impact 
            gameObject.SetActive(false);
        }
    }
}
