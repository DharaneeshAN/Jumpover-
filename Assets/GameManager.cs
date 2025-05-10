using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Spawning")]
    [Tooltip("Drag your obstacle prefab here")]
    public GameObject obstaclePrefab;

    [Tooltip("Drag an empty GameObject here to mark the spawn location")]
    public Transform spawnPoint;

    void Start()
    {
        // Kick off obstacle spawning
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // Wait between 0.2 and 2 seconds
            float waitTime = Random.Range(0.6f, 2f);
            yield return new WaitForSeconds(waitTime);

            // Instantiate a new obstacle at the spawnPoint
            Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
