using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;    // Fiendeskeppets prefab
    public float spawnInterval = 2f;  // Tiden mellan varje fiendeskepp

    private float nextSpawnTime;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        // Slumpa en X-position för att spawnas på toppen av skärmen
        float randomX = Random.Range(-8f, 8f);
        Vector3 spawnPosition = new Vector3(randomX, 6f, 0f);

        // Skapa fiendeskepp
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
