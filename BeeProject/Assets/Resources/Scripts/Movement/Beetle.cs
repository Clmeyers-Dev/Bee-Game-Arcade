using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : MonoBehaviour
{
    [SerializeField]
     private float RotateSpeed = 5f;
     [SerializeField]
     private float Radius = 0.1f;
 
    
     [SerializeField]
     private float _angle;
     [SerializeField]
     private GameObject _center;
 
      void Start()
     {
         
     }
 
      void Update()
     {
 
         _angle += RotateSpeed * Time.deltaTime;
 
         var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
         transform.position = (Vector2)_center.transform.position + offset;
     }
  
}
