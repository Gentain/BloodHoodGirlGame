using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior_Wasp : MonoBehaviour
{
    public enum Direction
    {
        left, right
    }

    public int life = 2;
    public GameObject target;
    [SerializeField] private Transform targetTrans;
    [SerializeField] private Transform enemyTrans;
    public float speed = 1.5f;
    Rigidbody2D rb;
    private Direction direction;
    Vector3 enemyVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyTrans = GetComponent<Transform>();

        try
        {
            target = GameObject.FindWithTag("Player");
            targetTrans = target.GetComponent<Transform>();
            if (targetTrans.position.x < enemyTrans.position.x)
            {
                direction = Direction.left;
                this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            }
            else if (enemyTrans.position.x < targetTrans.position.x)
            {
                direction = Direction.right;
                this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            enemyVector = (target.transform.position - enemyTrans.position).normalized;
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
                rb.AddForce(enemyVector * speed);

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
