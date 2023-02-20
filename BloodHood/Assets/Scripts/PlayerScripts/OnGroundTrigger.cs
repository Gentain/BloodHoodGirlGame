using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Enemy")
        {
            PlayerBehavior.jumpingHeight = 0f;
            PlayerBehavior.onGround = true;
            PlayerBehavior.jumping = false;
            Debug.Log("Hit");
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Enemy")
        {
            PlayerBehavior.jumpingHeight = 0f;
            PlayerBehavior.onGround = true;
            PlayerBehavior.jumping = false;
            Debug.Log("Hit");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Enemy")
        {
            PlayerBehavior.onGround = false;
            Debug.Log("Hit");
        }
    }
}
