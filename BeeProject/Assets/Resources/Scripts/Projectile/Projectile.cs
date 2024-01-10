using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private void Start()
    {
        InitializeRigidbody();
    }

    private void FixedUpdate()
    {
        MoveProjectile();
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision(other);
    }

    private void InitializeRigidbody()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the projectile GameObject.");
        }
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void HandleCollision(Collider2D other)
    {
        if (other.CompareTag("collision"))
        {
            Destroy(gameObject);
            EnemyManager enemyManager = other.GetComponent<EnemyManager>();
            if (enemyManager != null)
            {
                enemyManager.Hurt(damage);
            }
        }
    }
}
