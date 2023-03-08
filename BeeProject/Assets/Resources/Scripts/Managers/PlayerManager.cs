using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField]
    //private float upAndDown = 6;
    private HealthManager healthManager;
    [SerializeField]
    private float downwardSpeed = 6;
    [SerializeField]
    private float LeftAndRight = 6;
   // [SerializeField]
   // private float moveSpeedIncrement = .1f;
   // [SerializeField]
   // private float SpeedCap = 20f;
    public GameObject left;
    public GameObject right;
     public GameObject top;
    public GameObject bottom;
    public float score;
     public CinemachineImpulseSource	impulse;
    public TextMeshProUGUI scoreText;
    public AudioSource audioSource;
    public float flashLength = 0f;
    private float flashCounter = 0f;
    public SpriteRenderer playerSprite;
	public bool flashActive;
    public SpriteRenderer [] spriteArray  = new SpriteRenderer [1]; 
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }
    void Update()
    {
     // Debug.Log( healthManager.getNumberOfHealth());
     if(healthManager.getNumberOfHealth()<=0){
         Die();
     }
        scoreText .text = score+"";
       // if (downwardSpeed < SpeedCap)
         //   downwardSpeed += moveSpeedIncrement * Time.deltaTime;
           if (flashActive)
        {
            if (flashCounter > flashLength * .99f)
            {
                foreach(SpriteRenderer sprite in spriteArray){
                    if(sprite!=null)
                    sprite.color =new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
                }
              //  playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .82f)
            {
                foreach(SpriteRenderer sprite in spriteArray){
                    if(sprite!=null)
                    sprite.color =new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                }
               // playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                foreach(SpriteRenderer sprite in spriteArray){
                    if(sprite!=null)
                    sprite.color =new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
                }
               // playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49f)
            {
                foreach(SpriteRenderer sprite in spriteArray){
                    if(sprite!=null)
                    sprite.color =new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                }
              //  playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                foreach(SpriteRenderer sprite in spriteArray){
                    if(sprite!=null)
                    sprite.color =new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
                }
              //  playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                foreach(SpriteRenderer sprite in spriteArray){
                    if(sprite!=null)
                    sprite.color =new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                }
               // playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                foreach(SpriteRenderer sprite in spriteArray){
                    if(sprite!=null)
                    sprite.color =new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
                }
               // playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                foreach(SpriteRenderer sprite in spriteArray){
                    if(sprite!=null)
                    sprite.color =new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                }
                //playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }
    public float getSpeed()
    {
        return downwardSpeed;
    }
    public void slow()
    {
        downwardSpeed = downwardSpeed / 2;
    }
    [SerializeField]
   private SceneEnum sceneToLoad;
    private void Die(){
             SceneManager.LoadSceneAsync(sceneToLoad.ToString());
    }
    public Fire playerMainGunFire;
    // Update is called once per frame
    [SerializeField]
    private float Rightoffset;
    [SerializeField]
    private float LeftOffset;
      [SerializeField]
    private float topOffset;
    [SerializeField]
    private float BottomOffset;
    public float modifier = 1;
    public void addPoints(float p){
        impulse.GenerateImpulse();
        score += (p*modifier);
    }
    void FixedUpdate()
    {
        //   transform.Translate(Vector3.down*downwardSpeed*Time.deltaTime);
        
        if (Input.GetKey(KeyCode.W) && transform.position.y < top.transform.position.y+topOffset)// downwardSpeed > 6)
        {
            // downwardSpeed -=(upAndDown*2)*Time.deltaTime;
            transform.Translate(Vector3.up * LeftAndRight * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > bottom.transform.position.y+BottomOffset )//downwardSpeed < SpeedCap)
        {

            //downwardSpeed +=upAndDown*Time.deltaTime;
            transform.Translate(Vector3.down * LeftAndRight * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.A)&&transform.position.x>left.transform.position.x+LeftOffset)
        {
            transform.Translate(Vector3.left * LeftAndRight * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)&&transform.position.x<right.transform.position.x+Rightoffset)
        {
            transform.Translate(-Vector3.left * LeftAndRight * Time.deltaTime);
        }
        if(curHitTime<=hitTime){
            curHitTime+=Time.deltaTime;
        }
    }
    [SerializeField]
    private float hitTime;
    private float curHitTime;
    void OnTriggerEnter2D(Collider2D other)
    {
    //    Debug.Log("hit");
        if(other.tag == "collision"&&curHitTime>=hitTime){
            //TODO  create an explosion on impact 
              flashActive = true;
         flashCounter = flashLength;
            curHitTime = 0;
            healthManager.loseHealth();
        }
    }
}
