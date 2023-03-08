using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstShot : MonoBehaviour
{
   public float damage;
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    [SerializeField]
    private int bullets;
    public GameObject burstBullets;
    [SerializeField]
    private float maxtime;
    private float curtime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        curtime = maxtime;
    }

    // Update is called once per frame
    void Update()
    {
        if(curtime<=0 ){
            burst();
        }else{
            curtime-=Time.deltaTime;
        }
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
            burst();
            Destroy(gameObject);
            if(other.GetComponent<EnemyManager>()!=null)
            other.GetComponent<EnemyManager>().hurt(damage);
        }
    }
    public void burst(){
        float rotation = 0;
        for(int i = 0;i < bullets; i ++){
            Instantiate(burstBullets,transform.position,Quaternion.Euler(0,0,rotation));
            rotation +=15;
        }
        Destroy(gameObject);
    }
}
