using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float flashLength = 0f;
    private float flashCounter = 0f;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private bool flashActive;
    [SerializeField] private int sprites = 1;
    [SerializeField] private GameObject floatingPoints;
    [SerializeField] private SpriteRenderer[] spriteArray = new SpriteRenderer[1];
    [SerializeField] private int points;
    [SerializeField] private AudioSource audioPlayer;
    [SerializeField] private GameObject pointSpawnPoint;
    [SerializeField] private AudioClip sound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private float maxTime;
    private float curTimer;
    [SerializeField] private CinemachineImpulseSource impulse;

    void Start()
    {
        impulse = GetComponent<CinemachineImpulseSource>();
    }

    [SerializeField] private float pointTextOffset;

    void Update()
    {
        if (curTimer <= maxTime)
            curTimer += Time.deltaTime;

        if (health <= 0)
        {
            AddPoints(points);
            var floating = Instantiate(floatingPoints, transform.position, Quaternion.identity);
            floating.GetComponentInChildren<TextMesh>().text = points + "";
            impulse.GenerateImpulse();
            Destroy(gameObject);
        }

        if (flashActive)
        {
            float alpha = Mathf.PingPong(flashCounter / flashLength, 1f) * 0.5f + 0.5f;

            foreach (SpriteRenderer sprite in spriteArray)
            {
                if (sprite != null)
                    sprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, alpha);
            }

            flashCounter -= Time.deltaTime;

            if (flashCounter <= 0f)
            {
                foreach (SpriteRenderer sprite in spriteArray)
                {
                    if (sprite != null)
                        sprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                }
                flashActive = false;
            }
        }
    }

    public void Hurt(float damage)
    {
        flashActive = true;
        flashCounter = flashLength;
        health -= damage;

        if (curTimer >= maxTime)
        {
            audioPlayer.PlayOneShot(sound);
            curTimer = 0;
        }
    }

    public void AddPoints(int p)
    {
        PlayerManager player = FindObjectOfType<PlayerManager>();
        player.audioSource.PlayOneShot(deathSound);
        player.AddPoints(p);
    }
}
