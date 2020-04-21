using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    private float movementSpeed = 8;
    private float outOfBounds = 10;
    private Rigidbody playerRb;

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

        playerRb.AddForce(Vector3.forward * movementSpeed * verticalControl);
        playerRb.AddForce(Vector3.right * movementSpeed * horizontalControl);

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
}
