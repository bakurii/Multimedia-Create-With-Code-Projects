using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject yellowUp;

    // Start is called before the first frame update
    void Start()
    {
        yellowUp = GetComponent<GameObject>();
        float randomZ = Random.Range(-7, 7);
        float randomX = Random.Range(-7, 7);
        Vector3 position = new Vector3(randomZ, 0, randomX);
        yellowUp.transform.position = position;
        Instantiate(yellowUp);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
