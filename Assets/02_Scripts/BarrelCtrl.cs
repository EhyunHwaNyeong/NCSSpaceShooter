using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    const int HIT_COUNT = 3;
    const float DESTROY_EXP = 5.0f;
    const float DESTROY_BARREL = 3.0f;
    const float BARREL_MASS = 1.0f;
    const float UP_FORCE = 1500.0f;


    [SerializeField] GameObject expEffect;

    public Texture[] textures;
    new MeshRenderer renderer;

    Transform tr;
    Rigidbody rb;

    int hitCount = 0;

    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        renderer = GetComponentInChildren<MeshRenderer>();

        int idx = Random.Range(0, textures.Length);
        renderer.material.mainTexture = textures[idx];
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BULLET"))
        {
            if (++hitCount == HIT_COUNT)
            {
                ExpBarrel();
            }
        }
    }

    void ExpBarrel()
    {
        GameObject exp = Instantiate(expEffect, tr.position, Quaternion.identity);

        Destroy(exp, DESTROY_EXP);

        rb.mass = BARREL_MASS;
        rb.AddForce(Vector3.up * UP_FORCE);
        Destroy(gameObject, DESTROY_BARREL);

    }
}
