using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManagement gameManagement;
    private float minSpeed = 12;
    private float maxSpeed = 14;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    public int pointValue;
    public ParticleSystem explosionParticle;
    

    // Start is called before the first frame update
    void Start()
    {

        targetRb = GetComponent<Rigidbody>();
        gameManagement = GameObject.Find("GameManager").GetComponent<GameManagement>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if(gameManagement.isGameActive)
        Destroy(gameObject);
        gameManagement.UpdateScore(pointValue);
        Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);      
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManagement.GameOver();
        }      
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        float randomTorque = Random.Range(-maxTorque, maxTorque);
        return randomTorque;
    }

    Vector3 RandomSpawn()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
