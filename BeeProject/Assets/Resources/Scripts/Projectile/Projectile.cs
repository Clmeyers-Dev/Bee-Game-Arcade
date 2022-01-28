using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void FixedUpdate()
    {
        transform.Translate(Vector3.down*speed*Time.deltaTime);
    }
    public void setSpeed(float s){
        speed = s;
    }
}
