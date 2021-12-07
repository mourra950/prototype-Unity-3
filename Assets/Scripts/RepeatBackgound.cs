using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgound : MonoBehaviour
{
    // Start is called before the first frame update
    private float repeatedWidth;
    private Vector3 startpos;
    void Start()
    {
        startpos = transform.position;
        repeatedWidth = GetComponent<BoxCollider>().size.x / 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startpos.x - repeatedWidth)
        {
            transform.position = startpos;
        }
    }
}
