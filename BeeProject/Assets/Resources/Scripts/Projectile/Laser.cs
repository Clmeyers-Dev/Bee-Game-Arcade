using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public LineRenderer line;
    public Transform firePoint;
    public GameObject startVfx;
    public GameObject endVFX;
    private List<ParticleSystem> particles = new List<ParticleSystem>();
    void Start()
    {
            FillLists();
          DisableLaser();
        
    }

    // Update is called once per frame
    void Update()
    {
               RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, transform.forward.normalized, mask);
    

            Debug.DrawRay(transform.position,transform.forward,Color.green);      
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            enableLaser();
        }
        if(Input.GetKey(KeyCode.Mouse0)){
            UpdateLaser();
        }
        if(Input.GetKeyUp(KeyCode.Mouse0)){
            DisableLaser();
        }
    }
    void enableLaser(){
        line.enabled = true;
        for(int i =0; i<particles.Count;i++){
            particles[i].Play();
        }
    }
    public float length;
   public LayerMask mask;
   public float offset;
    void  UpdateLaser()
    {
        // var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);

      // line.SetPosition(0, (Vector2)firePoint.position);
       // startVFX.transform.position = (Vector2)firePoint.position;

      //  line.SetPosition(1, mousePos);

      //  Vector2 direction = mousePos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2) transform.position,  Vector2.down ,100,mask);
        if(hit)
        {
            Debug.Log(hit);
            line.SetPosition(1, new Vector3(0,hit.point.y,0));
            Debug.Log(hit.point);
        }
     
        endVFX.transform.position = new Vector3(startVfx.transform.position.x,line.GetPosition(1).y,0);// line.GetPosition(1);
         //   line.SetPosition(1,endVFX.transform.position);
       // var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
     
     // transform.rotation = Quaternion.AngleAxis(angle+offset,new Vector3(0,0,1) );
        // Debug.DrawRay(transform.position,transform.forward,Color.red);
 
         // endVFX.transform.position = hit.point;//.GetPosition(1);
    }
    public float offset2;
    void DisableLaser(){
        line.enabled = false;
        for(int i =0; i<particles.Count;i++){
            particles[i].Stop();
        }
    }
    public void fire(){

    }
    void FillLists(){
        for(int i = 0; i < startVfx.transform.childCount;i++){
            var ps = startVfx.transform.GetChild(i).GetComponent<ParticleSystem>();
            if(ps !=null)
            particles.Add(ps);
        }

        for(int i = 0; i < endVFX.transform.childCount;i++){
            var ps = endVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if(ps !=null)
            particles.Add(ps);
        }
    }
}
