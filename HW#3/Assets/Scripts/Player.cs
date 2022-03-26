using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15f;
    private Vector3 startpos;
    private bool hasReward = false;
    public GameObject restartbutton;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
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

    void LateUpdate()
    {
        if(hasReward && transform.position.x <= startpos.x)
        {
            Time.timeScale = 0;
            restartbutton.SetActive(true);

        }
        else if(!hasReward)
        {
            GameObject reward = GameObject.FindWithTag("Reward");
            float distance = Vector3.Distance(transform.position, reward.transform.position);
            if(distance < 3 && Input.GetKey("up"))
            {
                Destroy(reward);
                hasReward = true;
                transform.Rotate(0, 180, 0);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag.Equals("Barrier") == true)
        {
            Time.timeScale = 0;
            restartbutton.SetActive(true);
        }
    }
}
