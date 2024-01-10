using System.Collections;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float downwardSpeed = 6;
    [SerializeField] private float leftAndRightSpeed = 6;
    [SerializeField] private float rightOffset = 0;
    [SerializeField] private float leftOffset = 0;
    [SerializeField] private float topOffset = 0;
    [SerializeField] private float bottomOffset = 0;

    [Header("References")]
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private GameObject leftBoundary;
    [SerializeField] private GameObject rightBoundary;
    [SerializeField] private GameObject topBoundary;
    [SerializeField] private GameObject bottomBoundary;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private CinemachineImpulseSource impulse;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private SpriteRenderer[] spriteArray = new SpriteRenderer[1];

    [Header("Flash Effect Settings")]
    [SerializeField] private float flashLength = 0f;
    private float flashCounter = 0f;
    private bool flashActive;

    [Header("Hit Settings")]
    [SerializeField] private float hitTime = 0;
    private float curHitTime;

    [Header("Score Settings")]
    public float score;
    [SerializeField] private float scoreModifier = 1;

    [Header("Scene Settings")]
    [SerializeField] private SceneEnum sceneToLoad;

    public Fire playerMainGunFire;

    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    void Update()
    {
        HandleFlashEffect();
        UpdateScoreText();

        if (healthManager.getNumberOfHealth() <= 0)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        HandleMovementInput();
        curHitTime += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "collision" && curHitTime >= hitTime)
        {
            HandlePlayerCollision();
        }
    }

 void HandleFlashEffect()
{
    if (flashActive)
    {
        // Determine the alpha value based on the flashCounter
        float alpha = Mathf.Lerp(0f, 1f, flashCounter / flashLength);

        // Apply the alpha value to all sprite renderers in spriteArray
        foreach (SpriteRenderer sprite in spriteArray)
        {
            if (sprite != null)
            {
                sprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, alpha);
            }
        }

        // Decrease the flashCounter
        flashCounter -= Time.deltaTime;

        // Check if the flashing duration has ended
        if (flashCounter <= 0f)
        {
            // Reset the sprite colors to fully visible
            foreach (SpriteRenderer sprite in spriteArray)
            {
                if (sprite != null)
                {
                    sprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                }
            }

            // Deactivate the flash effect
            flashActive = false;
        }
    }
}


    void HandleMovementInput()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput * leftAndRightSpeed * Time.deltaTime,
                                       verticalInput * downwardSpeed * Time.deltaTime, 0);

        transform.Translate(movement);

        ClampPositionToBounds();
    }

    void ClampPositionToBounds()
    {
        float clampedX = Mathf.Clamp(transform.position.x, leftBoundary.transform.position.x + leftOffset,
                                                    rightBoundary.transform.position.x - rightOffset);

        float clampedY = Mathf.Clamp(transform.position.y, bottomBoundary.transform.position.y + bottomOffset,
                                                    topBoundary.transform.position.y - topOffset);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    void UpdateScoreText()
    {
        scoreText.text = score + "";
    }

    void HandlePlayerCollision()
    {
        flashActive = true;
        flashCounter = flashLength;
        curHitTime = 0;
        healthManager.loseHealth();
    }

    void Die()
    {
        SceneManager.LoadSceneAsync(sceneToLoad.ToString());
    }

    public void AddPoints(float points)
    {
        impulse.GenerateImpulse();
        score += points * scoreModifier;
    }
}
