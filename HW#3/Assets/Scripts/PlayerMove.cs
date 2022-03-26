using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int score = 0;
    public float speed = 15f;
    private Vector3 startpos;
    private bool hasReward = false;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = transform.position;

        if (Input.GetKey("right"))
        {
            vec.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("left"))
        {
            vec.x -= speed * Time.deltaTime;
        }

        transform.position = vec;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Reward") == true)
        { 
            transform.Rotate(0, 180, 0);
            Destroy(collision.gameObject);
            hasReward = true;
            score++;
        }
        else if (collision.gameObject.tag.Equals("Barrier") == true)
        {
            transform.position = startpos;
        }
    }
}
