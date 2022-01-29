using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
      

        //playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0){
            AddPoints(points);
            Destroy(gameObject);
        }
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
    public void hurt(float dmg){
        flashActive = true;
         flashCounter = flashLength;
        health -= dmg;
    }
    public void AddPoints(int p){

    }
}
