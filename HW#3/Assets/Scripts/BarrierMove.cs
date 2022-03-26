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
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            duration = Random.Range(0.03f, 3f);
            Vector3 move = transform.position;
            Vector3 start = transform.position;
            if (isdown)
            {
                aimedPos = new Vector3(0, 9, 0);
                while (transform.position.y < aimedPos.y)
                {
                    move.y += 0.2f;
                    transform.position = move;
                    yield return new WaitForSeconds(0.04f);
                }
            }
            else
            {
                aimedPos = new Vector3(0, 3.7f, 0);
                while (transform.position.y > aimedPos.y)
                {
                    move.y -= 0.2f;
                    transform.position = move;
                    yield return new WaitForSeconds(0.04f);
                }
            }
            isdown = !isdown;
            yield return new WaitForSeconds(duration);
        }
     
    }
}
