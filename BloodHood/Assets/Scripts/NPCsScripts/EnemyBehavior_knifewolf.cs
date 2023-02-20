using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior_knifewolf : MonoBehaviour
{
    public enum direction
    {
        left, right
    }

    public int life = 2;
    public GameObject target;
    [SerializeField] private Transform targetTrans;
    [SerializeField] private Transform enemyTrans;
    public float speed = 8.0f;
    private direction wolfDirection;
    public Animator anim;
    public float distanceEnemyToPlayer_x;
    public float distanceEnemyToPlayer_y;
    public float searchDistance_x = 10;
    public float searchDistance_y = 10;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        enemyTrans = GetComponent<Transform>();
        wolfDirection = direction.left;
        try
        {
            target = GameObject.FindWithTag("Player");
            targetTrans = target.GetComponent<Transform>();
        }
        catch (NullReferenceException ex)
        {

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PauseSystem.paused == false)
        {
            try
            {
                distanceEnemyToPlayer_x = Mathf.Abs(targetTrans.position.x - enemyTrans.position.x);
                distanceEnemyToPlayer_y = Mathf.Abs(targetTrans.position.y - enemyTrans.position.y);
                if (distanceEnemyToPlayer_x <= searchDistance_x && distanceEnemyToPlayer_y <= searchDistance_y)
                {
                    anim.Play("knifewolf_walk");
                    Vector3 enemyDirection = targetTrans.position - enemyTrans.position;
                    rb.AddForce(enemyDirection.normalized * speed);
                }
                else
                {
                    anim.Play("knifewolf_idle");
                }
            }
            catch (NullReferenceException ex)
            {

            }

            if (targetTrans.position.x < enemyTrans.position.x)
            {
                wolfDirection = direction.left;
                this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            }
            else if (enemyTrans.position.x < targetTrans.position.x)
            {
                wolfDirection = direction.right;
                this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }

            if (life <= 0)
            {
                Level2Target.targetKills++;
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

/*
  try
        {
            target = GameObject.FindWithTag("Player");
            targetTrans = target.GetComponent<Transform>();
            distanceGeneratorToPlayer_x = Mathf.Abs(targetTrans.position.x - enemyTrans.position.x);
            distanceGeneratorToPlayer_y = Mathf.Abs(targetTrans.position.y - enemyTrans.position.y);
            if (distanceGeneratorToPlayer_x <= searchDistance_x && distanceGeneratorToPlayer_y <= searchDistance_y)
            {
                GameObject newEnemy = Instantiate(spawnEnemy, generator.transform.position, Quaternion.identity) as GameObject;
            }
            else
            {
            }
        }
        catch (NullReferenceException ex)
        {

        }
*/