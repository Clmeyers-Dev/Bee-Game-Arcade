using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

     [SerializeField]
    private float fireangle;
    [SerializeField]
    public float fireSpeed = 0.5f;
    [SerializeField]
    private float timer;
    public Transform firepoint;
    [SerializeField]
    private GameObject bullet;
    public GameObject parent;
    public PlayerManager player;
    [SerializeField]
    public float burstFireSpeed =1;
    
   public AudioSource audioPlayer;
  public  AudioClip sound;
  public float currentSpeed;
  public void setBullet(GameObject b){
 bullet = b;
  }
  public void setFireSpeed(float s){
    currentSpeed = s;
  }
    void Start()
    {
      currentSpeed = fireSpeed;
       // parent = GetComponentInParent<GameObject>();
       player = GetComponentInParent<PlayerManager>();
      // audioPlayer = FindObjectOfType<AudioSource>();
    }
    public void  Update()
    {
        if(timer <=0){
        if(Input.GetKey(KeyCode.Space)){

  var shot =   Instantiate(bullet,firepoint.position,Quaternion.Euler(parent.transform.localEulerAngles.x,parent.transform.localEulerAngles.y,parent.transform.localEulerAngles.z+fireangle) );
    audioPlayer.PlayOneShot(sound);
            //shot.GetComponent<Projectile>().setSpeed( player.getSpeed() + 20);
            timer = currentSpeed;
        }
        }else{
            timer -= Time.deltaTime;
        }
    }
}
