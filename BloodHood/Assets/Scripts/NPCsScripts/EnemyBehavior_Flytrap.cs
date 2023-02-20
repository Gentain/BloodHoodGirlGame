using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior_Flytrap : MonoBehaviour
{
    public int life = 15;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb = GetComponent<Rigidbody2D>();
        if (life <= 0)
        {
            Level1Target.targetKills++;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (PauseSystem.paused == false)
        {
            if (col.gameObject.tag == "Knife")
            {
                life -= 5;
            }
            else if (col.gameObject.tag == "Bullet")
            {
                Destroy(col.gameObject);
                life -= 2;
            }
            Debug.Log(life);
        }
    }
}
