using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    const float TIME_INTER = 0.25f;
    const float INPUT_VALUE = 0.1f;
    Transform tr;
    Animation anime;
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float turnSpeed = 360.0f;
    void Start()
    {
        tr = GetComponent<Transform>();
        anime = GetComponent<Animation>();

        anime.Play("Idle");
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

        PlayerAnime(h, v);
    }

    void PlayerAnime(float h, float v)
    {
        if (v >= INPUT_VALUE)
        {
            anime.CrossFade("RunF", TIME_INTER);
        }
        else if (v <= -INPUT_VALUE)
        {
            anime.CrossFade("RunB", TIME_INTER);
        }
        else if (h >= INPUT_VALUE)
        {
            anime.CrossFade("RunR", TIME_INTER);
        }
        else if (h <= -INPUT_VALUE)
        {
            anime.CrossFade("RunL", TIME_INTER);
        }
        else
        {
            anime.CrossFade("Idle", TIME_INTER);
        }
    }   
}
