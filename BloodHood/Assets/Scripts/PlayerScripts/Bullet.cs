using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 shootVector;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        shootVector = Muzzle.directionVec_n;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(shootVector);
    }
}
