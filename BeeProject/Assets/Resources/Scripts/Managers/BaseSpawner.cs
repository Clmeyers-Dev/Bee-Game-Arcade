using System.Collections;
using UnityEngine;

public abstract class BaseSpawner : MonoBehaviour
{
    public float minSpawnTime;
    public float maxSpawnTime;
    public GameObject objectToSpawn;
    public BoxCollider2D spawnArea;

    protected float RandomSpawnTime => Random.Range(minSpawnTime, maxSpawnTime);

    protected virtual void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    protected abstract void Spawn();

    protected IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(RandomSpawnTime);
            Spawn();
        }
    }
}

public class ModifierSpawner : BaseSpawner
{
    protected override void Spawn()
    {
        float spawnPointX = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        Instantiate(objectToSpawn, new Vector3(spawnPointX, transform.position.y, 0), Quaternion.identity);
    }
}

public class EnemySpawner : BaseSpawner
{
    protected override void Spawn()
    {
        // Implement enemy spawning logic here
        // Example:
        // float spawnPointX = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
        // Instantiate(objectToSpawn, new Vector3(spawnPointX, transform.position.y, 0), Quaternion.identity);
    }
}
