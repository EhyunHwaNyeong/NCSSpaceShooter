using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Transform tr;
    public float moveSpeed = 10.0f;
    void Start()
    {
        tr = GetComponent<Transform>();
        
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Debug.Log($"h= {h}");
        Debug.Log($"v= {v}");
        // Transform.position
        //transform.position += new Vector3(0, 0, 1);
        // normalized vector
        tr.Translate(Vector3.forward * v * Time.deltaTime * moveSpeed, Space.Self);
    }
}
