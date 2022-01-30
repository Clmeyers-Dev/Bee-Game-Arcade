using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTut : MonoBehaviour
{
    public Camera cam;
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public GameObject startVFX;
    public GameObject endVFX;
    [SerializeField]
    private AudioSource audioSource;
    private Quaternion rotation;
    [SerializeField]
    private AudioClip sound;
    private List<ParticleSystem> particles = new List<ParticleSystem>();

    void Start()
    {
        FillLists();
        DisableLaser();
        cam = Camera.main;
       
    }
    
void Awake()
{
    FillLists();
    DisableLaser();
}
public float laserDamage;
    void Update()
    {
   
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
            EnableLaser();
        }
        
    
        if(Input.GetKey(KeyCode.Space))
        {
            if(lineRenderer.enabled == false){
                EnableLaser();
            }
        
            UpdateLaser();
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            DisableLaser();
             audioSource.Stop();
        }else{
           
        }

      //  RotateToMouse();
    }

    void EnableLaser()
    {
        lineRenderer.enabled = true;

        for(int i=0; i<particles.Count; i++)
            particles[i].Play();
    }
    public LayerMask mask;
    void UpdateLaser()
    {
          var mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);

        lineRenderer.SetPosition(0, (Vector2)firePoint.position);
        startVFX.transform.position = (Vector2)firePoint.position;

        lineRenderer.SetPosition(1, mousePos);

        Vector2 direction = mousePos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, direction.magnitude,mask);

        if(hit)
        {
            lineRenderer.SetPosition(1, hit.point);
            if(hit.collider.gameObject.GetComponent<EnemyManager>()!=null){
                hit.collider.gameObject.GetComponent<EnemyManager>().hurt(laserDamage);
                if(!audioSource.isPlaying)
                audioSource.PlayOneShot(sound);
            }
        }else{
           
        }

        endVFX.transform.position = lineRenderer.GetPosition(1);
    }

    void DisableLaser()
    {
        lineRenderer.enabled = false;

        for(int i=0; i<particles.Count; i++)
            particles[i].Stop();
    }

    void RotateToMouse ()
    {
        Vector2 direction = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation.eulerAngles = new Vector3(0,0,angle);
        transform.rotation = rotation;
    }

    void FillLists()
    {
        for(int i=0; i<startVFX.transform.childCount; i++)
        {
            var ps = startVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if(ps != null)
                particles.Add(ps);
        }

        for(int i=0; i<endVFX.transform.childCount; i++)
        {
            var ps = endVFX.transform.GetChild(i).GetComponent<ParticleSystem>();
            if(ps != null)
                particles.Add(ps);
        }
    }
}
