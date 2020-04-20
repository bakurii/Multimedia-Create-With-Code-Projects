using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacklePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    private PLayerControll playerControlScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = GameObject.Find("Barret").GetComponent<PLayerControll>();
        InvokeRepeating("NewObstackle", startDelay, repeatRate);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NewObstackle()
    {
        if (playerControlScript.gameOver == false)
        {
            Instantiate(obstacklePrefab, spawnPos, obstacklePrefab.transform.rotation);
        }       
    }
}
