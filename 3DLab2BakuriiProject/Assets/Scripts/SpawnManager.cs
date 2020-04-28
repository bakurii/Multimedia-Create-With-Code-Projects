using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject powerupPrefab;
    public GameObject[] enemyArray;
    public GameObject enemy1;

    private EnemyMovement enemyScript;
    private PlayerController playerScript;

    // Start is called before the first frame update
    void Start()
    {
        InstantiatePowerup();
        InvokeRepeating("RandomizedEnemiesSpawn", 0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        InstantiatePowerup();
        DeleteOutofBounds();
    }
    
    void InstantiatePowerup()
    {
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
        {
            Instantiate<GameObject>(powerupPrefab, RandomPosition(), powerupPrefab.transform.rotation);
        }   
    }

    // Deletes enemies by the tag "Enemy" when they move out of the playground
    void DeleteOutofBounds()
    {
        enemy1 = GameObject.FindWithTag("Enemy");
        if (enemy1 == true && enemy1.transform.position.z < -14)
        {
            Destroy(GameObject.FindWithTag("Enemy"));
        }
    }

    // Spawn randomized enemies from list.
    void RandomizedEnemiesSpawn()
    {
        int arrayIndex = Random.Range(0, enemyArray.Length);

        float randomZ = Random.Range(-8, 8);
        Vector3 enemyPos = new Vector3(randomZ, 0, 13);

        Instantiate(enemyArray[arrayIndex], enemyPos, enemyArray[arrayIndex].transform.rotation);
    }

    // Generates random coordinates for Z and X axis with seleced range for yellow powerup thing.
    Vector3 RandomPosition()
    {
        float randomZ = Random.Range(-8, 8);
        float randomX = Random.Range(-8, 8);
        Vector3 position = new Vector3(randomZ, 0, randomX);

        return position;
    }
}
