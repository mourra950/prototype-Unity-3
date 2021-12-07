using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerController PlCtrl;
    private float leftbound = -15.0f;
    private Rigidbody ObstacleRb;
    public float movment = 0;
    void Start()
    {
        ObstacleRb = GetComponent<Rigidbody>();
        PlCtrl = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlCtrl.gameOver == false)
            transform.Translate(Vector3.left * Time.deltaTime * movment);
        if (transform.position.x < leftbound && gameObject.CompareTag("Obstacle"))
            Destroy(gameObject);
    }
}
