using UnityEngine;

public class BasicWasp : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 5f;
    [SerializeField] private float verticalSpeed = 5f;
    [SerializeField] private float maxTime = 5f;

    private float timer;
    private int direction = 1; // 1 for right, -1 for left

    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        MoveVertically();
        MoveHorizontally();
    }

    private void MoveVertically()
    {
        transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime);
    }

    private void MoveHorizontally()
    {
        timer += Time.deltaTime;

        if (timer >= maxTime)
        {
            ToggleDirection();
            ResetTimer();
        }

        float horizontalMovement = direction * horizontalSpeed;
        transform.Translate(Vector3.right * horizontalMovement * Time.deltaTime);
    }

    private void ToggleDirection()
    {
        direction *= -1; // Toggle between 1 and -1
    }

    private void ResetTimer()
    {
        timer = 0f;
        maxTime = Random.Range(1f, 6f);
    }
}
