using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWasps : MonoBehaviour
{
    public float deleteTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (PauseSystem.paused == false)
        {
            Destroy(gameObject, deleteTime);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
