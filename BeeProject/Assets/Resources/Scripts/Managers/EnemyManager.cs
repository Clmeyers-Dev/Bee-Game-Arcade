using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float health;
    public float flashLength = 0f;
    private float flashCounter = 0f;
    public SpriteRenderer playerSprite;
	public bool flashActive;
    public int sprites= 1;
    public SpriteRenderer [] spriteArray  = new SpriteRenderer [1];  
    [SerializeField]
    private int points;
    public AudioSource audioPlayer;
    public AudioClip sound;
    public AudioClip deathSound;
    public float maxTime;
    private float curTimer;
    public CinemachineImpulseSource	impulse;
    void Start()
    {
      impulse = GetComponent<CinemachineImpulseSource>();
      

        //playerSprite = GetComponentInChildren<SpriteRenderer>();
    }
   


    // Update is called once per frame
    void Update()
    {
        if(curTimer<=maxTime)
        curTimer+=Time.deltaTime;
        if(health<=0){
            AddPoints(points);
            impulse.GenerateImpulse();
          //  audioPlayer.PlayOneShot(deathSound);
            Destroy(gameObject);
        }
         if (flashActive)
        {
            if (flashCounter > flashLength * .99f)
            {
                foreach(SpriteRenderer sprite in spriteArray){
                    if(sprite!=null)
                    sprite.color =new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, .5f);
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
                    sprite.color =new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, .5f);
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
                    sprite.color =new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, .5f);
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
                    sprite.color =new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, .5f);
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
    public void hurt(float dmg){
        flashActive = true;
         flashCounter = flashLength;
        health -= dmg;
        if(curTimer >=maxTime){
           // Debug.Log("play sound");
//          audioPlayer.PlayOneShot(sound);
          curTimer = 0;
        }
    }
  
    public void AddPoints(int p){
  PlayerManager player = FindObjectOfType<PlayerManager>();
  player.audioSource.PlayOneShot(deathSound);
  player.addPoints(p);
    }
}
