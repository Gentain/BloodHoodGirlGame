using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUIappears : MonoBehaviour
{
    public GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (PauseSystem.paused == true)
        {
            pauseUI.SetActive(true);
        }
        else if (PauseSystem.paused == false)
        {
            pauseUI.SetActive(false);
        }
    }
        
}
