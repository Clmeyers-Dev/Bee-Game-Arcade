using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Camera cam;
    public LineRenderer line;
    public Transform firePoint;
    public GameObject startVFX;
    public GameObject endVFX;

    private List<ParticleSystem> particles = new List<ParticleSystem>();

    [SerializeField] private float length;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float offset;
    [SerializeField] private float offset2;

    private void Start()
    {
        FillLists();
        DisableLaser();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            EnableLaser();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            UpdateLaser();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            DisableLaser();
        }
    }

    private void EnableLaser()
    {
        line.enabled = true;

        foreach (ParticleSystem ps in particles)
        {
            ps.Play();
        }
    }

    private void UpdateLaser()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 100, mask);

        if (hit)
        {
            line.SetPosition(1, new Vector3(0, hit.point.y, 0));
        }

        endVFX.transform.position = new Vector3(startVFX.transform.position.x, line.GetPosition(1).y, 0);
    }

    private void DisableLaser()
    {
        line.enabled = false;

        foreach (ParticleSystem ps in particles)
        {
            ps.Stop();
        }
    }

    private void FillLists()
    {
        AddParticleSystems(startVFX);
        AddParticleSystems(endVFX);
    }

    private void AddParticleSystems(GameObject vfxObject)
    {
        for (int i = 0; i < vfxObject.transform.childCount; i++)
        {
            ParticleSystem ps = vfxObject.transform.GetChild(i).GetComponent<ParticleSystem>();

            if (ps != null)
            {
                particles.Add(ps);
            }
        }
    }
}
