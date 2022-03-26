using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierMove : MonoBehaviour
{
    private float duration = 1f;
    private bool isdown = true;
    private Vector3 aimedPos; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        duration = Random.Range(0.5f, 5f);
        Vector3 move = transform.position;
        Vector3 start = transform.position;
        if (isdown)
        {
            aimedPos = new Vector3(0,9,0);
            while (transform.position.y < aimedPos.y)
            {
                print(aimedPos.y);
                move.y += 0.2f;
                transform.position = move;
                yield return new WaitForSecondsRealtime(5);
            }
        }
        else
        {
            aimedPos = new Vector3(0, 3, 0);
            while (transform.position.y > aimedPos.y)
            {
                print(aimedPos.y);
                move.y -= 0.2f;
                transform.position = move;
                yield return new WaitForSecondsRealtime(5);
            }
        }
        isdown = !isdown;
        //transform.position = Vector3.MoveTowards(transform.position, aimedPos, 0.5f);
        yield return new WaitForSeconds(duration*10);
    }
}
