using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public SpriteRenderer renderer;
    public BoxCollider2D collider;
    float slashingTime = 1.0f;
    float slashingTime_n = 0.0f;
   public static bool slashing = false;


    // Start is called before the first frame update
    void Start()
    {

        float slashingTime_n = 0.0f;
        renderer = this.GetComponent<SpriteRenderer>();
        collider = this.GetComponent<BoxCollider2D>();
        renderer.enabled = false;
        collider.enabled = false;
        slashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseSystem.paused == false)
        {
            if (PlayerBehavior.swiningKnife == true)
            {
                slashing = true;
            }
            if (slashing == true && slashingTime_n <= 1.0f)
            {
                renderer.enabled = true;
                collider.enabled = true;
                slashingTime_n += Time.deltaTime;
            }
            else if (slashing == true && slashingTime_n > 1.0f)
            {
                renderer.enabled = false;
                collider.enabled = false;
                slashingTime_n = 0f;
                slashing = false;
                PlayerBehavior.swiningKnife = false;
            }
        }
    }


}
