using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedForce : MonoBehaviour
{
    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        body.AddForce(4, 4, 4);
    }
}
