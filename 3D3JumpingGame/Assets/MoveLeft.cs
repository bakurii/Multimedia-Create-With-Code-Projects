using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMoveLeft : MonoBehaviour
{
    //public GameObject gameObject1;
    public float movementSpeed = 5;
    private PLayerControll playerControlScript;
    private float leftBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = GameObject.Find("Barret").GetComponent<PLayerControll>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControlScript.gameOver == false)
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
