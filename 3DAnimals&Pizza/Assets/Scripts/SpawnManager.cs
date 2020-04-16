using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalArray;
    private float spawnRangeX = 18;
    private float spawnPosiZ = 18;
    private float startDelay = 1.5f;
    private float spawnInterwall = 1f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimals", startDelay, spawnInterwall);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomAnimals()
    {
        int animalIndex = Random.Range(0, animalArray.Length);

        Instantiate(animalArray[animalIndex], new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosiZ),
            animalArray[animalIndex].transform.rotation);
    }
}
