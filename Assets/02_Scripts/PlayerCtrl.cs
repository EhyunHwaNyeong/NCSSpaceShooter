using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] Transform tr;
    [SerializeField] float moveSpeed = 10.0f;
    [SerializeField] float turnSpeed = 360.0f;
    void Start()
    {
        tr = GetComponent<Transform>();
        
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");
        // Transform.position
        // transform.position += new Vector3(0, 0, 1);
        // normalized vector
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);
        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);
    }
}
