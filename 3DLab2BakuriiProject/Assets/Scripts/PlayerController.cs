using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    private float movementSpeed = 22;
    private float movementForce = 10;
    private float outOfBounds = 10;
    private Rigidbody playerRb;

    private SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        PlayGround();       
    }

    void MovePlayer()
    {
        float horizontalControl = Input.GetAxis("Horizontal");
        float verticalControl = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * movementSpeed * movementForce * verticalControl);
        playerRb.AddForce(Vector3.right * movementSpeed * movementForce * horizontalControl);

    }

    void PlayGround()
    {
        if (transform.position.z < -outOfBounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -outOfBounds);
        }

        if (transform.position.z > outOfBounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, outOfBounds);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            Debug.Log("PLAYER 1POINT");     
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPLayer = collision.gameObject.transform.position - transform.position;
        }
    }
}
