using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15f;
    private Vector3 startpos;
    private bool hasReward = false;
    public GameObject restartbutton;
    private bool pov = false;
    public GameObject cam1;
    public GameObject cam2;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        startpos = transform.position;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = transform.position;

        if (Input.GetKey("right"))
        {
            vec.x += speed * Time.deltaTime;
            GetComponent<Animator>().Play("Fox_Walk");

        }
        if (Input.GetKey("left"))
        {
            vec.x -= speed * Time.deltaTime;
            GetComponent<Animator>().Play("Fox_Walk");
        }

        transform.position = vec;

        if (Input.GetKeyDown("space"))
        {
            pov = !pov;
            cam2.SetActive(pov);
            cam1.SetActive(!pov);
        }
    }

    void LateUpdate()
    {
        if(hasReward && transform.position.x <= startpos.x)
        {
            GetComponent<AudioSource>().Stop();
            Time.timeScale = 0;
            restartbutton.SetActive(true);

        }
        else if(!hasReward)
        {
            GameObject reward = GameObject.FindWithTag("Reward");
            float distance = Vector3.Distance(transform.position, reward.transform.position);
            if(distance < 3 && Input.GetKey("up"))
            {
                GetComponent<AudioSource>().Pause();
                reward.GetComponent<AudioSource>().Play();
                Destroy(reward, 0.6f);
                GetComponent<AudioSource>().UnPause();
                hasReward = true;
                transform.Rotate(0, 180, 0);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag.Equals("Barrier") == true)
        {
            GetComponent<AudioSource>().Stop();
            Time.timeScale = 0;
            restartbutton.SetActive(true);
        }
    }
}
