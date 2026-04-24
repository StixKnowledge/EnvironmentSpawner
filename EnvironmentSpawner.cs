using UnityEngine;
using System.Collections.Generic;

public class EnvironmentSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform player;
    [SerializeField] private GameObject segmentPrefab;

    [Header("Settings")]
    [SerializeField] private int initialSegments = 5;
    [SerializeField] private float segmentLength = 20f; // Distance from start of segment to EndPoint

    private Queue<GameObject> activeSegments = new Queue<GameObject>();
    private float spawnX = 0f;

    void Start()
    {
        // Initial spawn of segments to fill the screen
        for (int i = 0; i < initialSegments; i++)
        {
            SpawnSegment();
        }
    }

    void Update()
    {
        // If the player has moved past the first active segment, recycle it
        // We check if player.x > firstSegment.x + segmentLength
        if (player.position.x > activeSegments.Peek().transform.position.x + segmentLength)
        {
            RecycleSegment();
        }
    }

    private void SpawnSegment()
    {
        GameObject segment = Instantiate(segmentPrefab, new Vector3(spawnX, 0, 0), Quaternion.identity);
        activeSegments.Enqueue(segment);
        spawnX += segmentLength;
    }

    private void RecycleSegment()
    {
        // Take the segment from the back
        GameObject segment = activeSegments.Dequeue();

        // Move it to the front
        segment.transform.position = new Vector3(spawnX, 0, 0);

        // Update the spawn position for the next one
        activeSegments.Enqueue(segment);
        spawnX += segmentLength;
    }
}