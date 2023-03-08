using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
     //the point the background goes back to start
     [SerializeField]
     private float reset = 19.2f;
 
     //the point where the background goes after a reset
     [SerializeField]
     private float startPoint;
 
     //the speed of movement
     [SerializeField]
     private float speed;
 
     public GameObject otherBackground;
     
 
     void Update () {
 
         SpriteRenderer sRenderer = otherBackground.GetComponent<SpriteRenderer>();
         startPoint = transform.position.y - sRenderer.bounds.size.y*2;
 
         //if the background is at reset point, move it to startPoint
         if(reset <= transform.position.y) {
             transform.position = (new Vector3(0, startPoint, 0));
         }
 
         //EnemySpawner.speedPlus is a static float
        // speed = 0.05f + EnemySpawner.speedPlus;
 
         //Move the backgound up
         transform.position += new Vector3(0,speed,0);
}
}
