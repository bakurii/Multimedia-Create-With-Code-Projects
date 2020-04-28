using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 150f;

    private Rigidbody enemyRb;
    private Rigidbody bossEnemyRb;
    private SpawnManager spawnManager;
    public static bool asd;

    // Start is called before the first frame update
    void Start()
    {
        bossEnemyRb = GetComponent<Rigidbody>();
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce(Vector3.forward * -speed);
        bossEnemyRb.AddForce(Vector3.forward * -speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            Debug.Log("ENEMY 1POINT");
        }
    }
}
