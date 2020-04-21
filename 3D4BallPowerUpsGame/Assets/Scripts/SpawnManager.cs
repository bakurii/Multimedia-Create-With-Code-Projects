using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int enemyCount;
    private float spawnRange = 9.0f;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate<GameObject>(powerupPrefab, GeneratePosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyBehaviour>().Length;
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate<GameObject>(powerupPrefab, GeneratePosition(), powerupPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate<GameObject>(enemyPrefab, GeneratePosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GeneratePosition()
    {
        float enemyPositionX = Random.Range(-9, 9);
        float enemyPositionZ = Random.Range(-9, 9);

        Vector3 randomPosition = new Vector3(enemyPositionX, 0, enemyPositionZ);

        return randomPosition;
    }
}
