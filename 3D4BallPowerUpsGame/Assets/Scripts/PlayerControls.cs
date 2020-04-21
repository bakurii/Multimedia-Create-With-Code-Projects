using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focusPoint;
    public GameObject powerupIndicator;
    public float speed = 5;
    public float powerUpStrength = 5;
    public bool hasPowerUp = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focusPoint = GameObject.Find("FocusPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float moveForward = Input.GetAxis("Vertical");

        playerRb.AddForce(focusPoint.transform.forward * moveForward * speed);

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.4f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDown());
        }
    }

    IEnumerator PowerupCountDown()
    {
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPLayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPLayer * powerUpStrength, ForceMode.Impulse);

            Debug.Log("Collided with: " + collision.gameObject.name + " with power set to" + hasPowerUp);
        }
    }
}
