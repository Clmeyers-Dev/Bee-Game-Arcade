using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   public float damage;
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
    void OnTriggerEnter2D(Collider2D other)
    {
//         Debug.Log("hit");
        if(other.tag == "collision"){
            Destroy(gameObject);
            if(other.GetComponent<EnemyManager>()!=null)
            other.GetComponent<EnemyManager>().hurt(damage);
        }
    }
}
