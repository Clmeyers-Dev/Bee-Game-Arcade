using System.Collections;
using UnityEngine;

public class Beetle : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2f;
    [SerializeField]
    private float zigzagAmplitude = 2f;
    [SerializeField]
    private float zigzagFrequency = 2f;

    private Vector2 startPosition;
    private float timeElapsed;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        MoveInZigzagPattern();
    }

    void MoveInZigzagPattern()
    {
        timeElapsed += Time.deltaTime;

        float xOffset = Mathf.Sin(timeElapsed * zigzagFrequency) * zigzagAmplitude;
        float yOffset = Mathf.Cos(timeElapsed * zigzagFrequency) * zigzagAmplitude;

        Vector2 zigzagOffset = new Vector2(xOffset, yOffset);
        Vector2 newPosition = startPosition + zigzagOffset;

        transform.position = Vector2.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }
}
