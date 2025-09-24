using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    const float TIME_INTER = 0.25f;
    const float INPUT_VALUE = 0.1f;
    const float TURN_SPEED = 360.0f;
    Transform tr;
    Animation anime;
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] float turnSpeed = TURN_SPEED;
    readonly float initHp = 100.0f;
    float currHp;
    public delegate void PlayerDieHandler();
    public static event PlayerDieHandler OnPlayerDie;
    IEnumerator Start()
    {
        currHp = initHp;
        tr = GetComponent<Transform>();
        anime = GetComponent<Animation>();

        anime.Play("Idle");

        turnSpeed = 0.0f;
        yield return new WaitForSeconds(0.3f);
        turnSpeed = TURN_SPEED;
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
    void OnTriggerEnter(Collider coll)
    {
        if (currHp >= 0.0f && coll.CompareTag("PUNCH"))
        {
            currHp -= 10.0f;
            Debug.Log($"Player hp = {currHp / initHp}");
            if (currHp <= 0.0f)
            {
                PlayerDie();
            }
        }
    }
    void PlayerDie()
    {
        Debug.Log("Player Die !");

        // GameObject[] monsters = GameObject.FindGameObjectsWithTag("MONSTER");
        // foreach (GameObject monster in monsters)
        // {
        //     monster.SendMessage("OnPlayerDie", SendMessageOptions.DontRequireReceiver);
        // }
        OnPlayerDie();
    }
}
