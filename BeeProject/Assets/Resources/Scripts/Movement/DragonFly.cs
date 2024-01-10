using UnityEngine;

public class DragonFly : MonoBehaviour
{
    private Vector3 start;
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float verticalSpeed = 5f;
    [SerializeField] private float maxTime = 5f; // Adjust the default value as needed

    private float timer;
    private bool movingRight;

    void Start()
    {
        start = transform.position;
        ResetTimer();
    }

    void Update()
    {
        MoveUpDown();
        MoveHorizontally();
    }

    void MoveUpDown()
    {
        transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime);
    }

    void MoveHorizontally()
    {
        timer += Time.deltaTime;

        if (timer >= maxTime)
        {
            movingRight = !movingRight;
            ResetTimer();
        }

        if (movingRight)
        {
            transform.Translate(Vector3.right * horizontalSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * horizontalSpeed * Time.deltaTime);
        }
    }

    void ResetTimer()
    {
        timer = 0f;
        maxTime = Random.Range(1f, 6f); // Adjust the range of random values as needed
    }
}
