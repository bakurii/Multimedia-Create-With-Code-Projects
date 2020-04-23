using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;
    public float speed2 = 30f;

    public Rigidbody enemyRb;
    public Rigidbody bossEnemyRb;

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
        bossEnemyRb.AddForce(Vector3.forward * -speed2);
    }
}
