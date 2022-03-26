using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;

    // Start is called before the first frame update
    void Start()
    {
        Offset = this.transform.position - Target.position;
    }

   void  LateUpdate()
    {
        transform.position = Offset + Target.position * 1.01f;
    }
}
