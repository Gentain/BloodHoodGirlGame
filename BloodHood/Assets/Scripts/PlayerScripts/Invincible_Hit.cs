using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible_Hit : MonoBehaviour
{
    public static float invincibleTime;
    private float maxInvincibleTime = 3.0f;
    static public bool invincibled_Hit;

    // Start is called before the first frame update
    void Start()
    {
        invincibled_Hit = false;
        invincibleTime = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (invincibled_Hit == true)
        {
            invincibleTime += Time.deltaTime;
            if(invincibleTime >= maxInvincibleTime)
            {

                invincibled_Hit = false;
            }
        }
    }

    static public void beInvincible()
    {
        if (invincibled_Hit == false)
        {
            invincibleTime = 0.0f;
            invincibled_Hit = true;
        }
    }
}
