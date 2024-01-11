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

     public AudioSource audioSource;
    [SerializeField] private AudioClip sound;

    private Quaternion rotation;
    private List<ParticleSystem> particles = new List<ParticleSystem>();

    public float laserDamage;
    public LayerMask mask;

    void Start()
    {
        FillLists();
        DisableLaser();
        cam = Camera.main;
        audioSource = GetComponent<AudioSource>();
    }

    void Awake()
    {
        FillLists();
        DisableLaser();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EnableLaser();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (!lineRenderer.enabled)
            {
                EnableLaser();
            }

            UpdateLaser();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            DisableLaser();
            audioSource.Stop();
        }
    }

    void EnableLaser()
    {
        lineRenderer.enabled = true;

        foreach (ParticleSystem ps in particles)
        {
            ps.Play();
        }
    }

    void UpdateLaser()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        lineRenderer.SetPosition(0, firePoint.position);
        startVFX.transform.position = firePoint.position;

        if (mousePos.y < transform.position.y)
            lineRenderer.SetPosition(1, mousePos);

        Vector2 direction = mousePos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position, direction.normalized, direction.magnitude, mask);

        if (hit)
        {
            lineRenderer.SetPosition(1, hit.point);

            if (hit.collider.gameObject.GetComponent<EnemyManager>() != null)
            {
                hit.collider.gameObject.GetComponent<EnemyManager>().Hurt(laserDamage);

                if (!audioSource.isPlaying)
                    audioSource.PlayOneShot(sound);
            }
        }

        endVFX.transform.position = lineRenderer.GetPosition(1);
    }

    void DisableLaser()
    {
        lineRenderer.enabled = false;

        foreach (ParticleSystem ps in particles)
        {
            ps.Stop();
        }
    }

    void FillLists()
    {
        foreach (Transform child in startVFX.transform)
        {
            var ps = child.GetComponent<ParticleSystem>();
            if (ps != null)
                particles.Add(ps);
        }

        foreach (Transform child in endVFX.transform)
        {
            var ps = child.GetComponent<ParticleSystem>();
            if (ps != null)
                particles.Add(ps);
        }
    }
}
