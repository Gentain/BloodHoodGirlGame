using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    float rotation_speed = 5.0f;
    public static float present_rotation_z = 0.0f;
    float move_rotation_z;

    // Start is called before the first frame update
    void Start()
    {
        present_rotation_z = transform.localEulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseSystem.paused == false)
        {
            if (this.transform.localEulerAngles.z <= 90f || this.transform.localEulerAngles.z >= -90f)
            {
                if (Input.GetKey(KeyCode.W) || Input.GetKey("joystick button 4"))
                {
                    transform.Rotate(0, 0, rotation_speed);
                }

                else if (Input.GetKey(KeyCode.S) || Input.GetAxis("LTrigger") > 0)
                {
                    transform.Rotate(0, 0, -rotation_speed);
                }
            }
        }
    }
}

