using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstShot : MonoBehaviour
{
    public float damage;
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    [SerializeField] private int bullets;
    public GameObject burstBulletPrefab;
    private List<GameObject> burstBulletsPool = new List<GameObject>();
    [SerializeField] private float maxTime;
    private float currentTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitializeBurstBulletsPool();
        currentTime = maxTime;
    }

    void Update()
    {
        if (currentTime <= 0)
        {
            Explode();
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        MoveBullet();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "collision")
        {
            Explode();
            Destroy(gameObject);
            if (other.GetComponent<EnemyManager>() != null)
            {
                other.GetComponent<EnemyManager>().Hurt(damage);
            }
        }
    }

    void MoveBullet()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void Explode()
    {
        float rotation = 0;
        for (int i = 0; i < bullets; i++)
        {
            GameObject burstBullet = GetPooledBurstBullet();
            burstBullet.transform.position = transform.position;
            burstBullet.transform.rotation = Quaternion.Euler(0, 0, rotation);
            burstBullet.SetActive(true);
            rotation += 15;
        }
        gameObject.SetActive(false);
    }

    void InitializeBurstBulletsPool()
    {
        for (int i = 0; i < bullets; i++)
        {
            GameObject burstBullet = Instantiate(burstBulletPrefab);
            burstBullet.SetActive(false);
            burstBulletsPool.Add(burstBullet);
        }
    }

    GameObject GetPooledBurstBullet()
    {
        foreach (GameObject burstBullet in burstBulletsPool)
        {
            if (!burstBullet.activeInHierarchy)
            {
                return burstBullet;
            }
        }
        return null;
    }
}
