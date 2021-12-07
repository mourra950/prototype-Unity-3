using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public float delay = 3;
    public float repetation = 5;
    private PlayerController PlCtrl;
    public GameObject obstacles;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    void Start()
    {
        InvokeRepeating("ObstacletInstantiate", delay, repetation);
        PlCtrl = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ObstacletInstantiate()
    {
        if (PlCtrl.gameOver == false)
            Instantiate(obstacles, spawnPosition, obstacles.transform.rotation);
    }
}
