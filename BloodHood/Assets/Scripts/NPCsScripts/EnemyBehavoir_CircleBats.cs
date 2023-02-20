using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavoir_CircleBats : MonoBehaviour
{
    public int life = 3;
    public float speed = 2.0f;
    public float circle_rad = 1.0f;
    public Animator anim;
    Vector3 initPos;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.Play("bat_flying");
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseSystem.paused == false)
        {
            CircleMoving();
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void CircleMoving()
    {
        Vector3 PosN;
        PosN.x = circle_rad * Mathf.Cos(Time.time * speed);
        PosN.y = circle_rad * Mathf.Sin(Time.time * speed);
        PosN.z = 0;
        transform.position = new Vector3(initPos.x + PosN.x, initPos.y + PosN.y, initPos.z + PosN.z);
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
