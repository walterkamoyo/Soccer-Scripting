using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;

    void Start()
    {

        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateRandomSpawnPosition(), enemyPrefab.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            Instantiate(powerupPrefab, GenerateRandomSpawnPosition(), enemyPrefab.transform.rotation);
            SpawnEnemyWave(waveNumber);    
        }

    }

    private Vector3 GenerateRandomSpawnPosition() {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomSpawnPosition = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomSpawnPosition;

    }

    void SpawnEnemyWave(int enemiesToSpawn) {

        for (int i = 0; i < enemiesToSpawn; i++) {
            Instantiate(enemyPrefab, GenerateRandomSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
