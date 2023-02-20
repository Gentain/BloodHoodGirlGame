using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior_Bats : MonoBehaviour
{
    public int life = 2;
    public GameObject target;
    [SerializeField] private Transform targetTrans;
    [SerializeField] private Transform enemyTrans;
    public float speed = 2.0f;
    public Animator anim;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyTrans = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        anim.Play("bat_flying");
        try
        {
            target = GameObject.FindWithTag("Player");
        }
        catch (NullReferenceException ex)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseSystem.paused == false)
        {
            try
            {
                Vector3 enemyDirection = target.transform.position - enemyTrans.position;
                rb.AddForce(enemyDirection.normalized * speed);
            }
            catch (NullReferenceException ex)
            {

            }

            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (PauseSystem.paused == false)
        {
            if (col.gameObject.tag == "Knife")
            {
                life -= 10;
            }
            if (col.gameObject.tag == "Bullet")
            {
                life -= 2;
                Destroy(col.gameObject);
            }
            Debug.Log(life);
        }
    }
}
