using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseSystem : MonoBehaviour
{
    static public bool paused;
    public GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
        {
            if (paused == false)
            {
                paused = true;
                pauseUI.SetActive(true);
            }
            else if (paused == true)
            {
                paused = false;
                pauseUI.SetActive(false);
            }
        }
        if (paused == true)
        {
            Debug.Log("Stop!!");
            Time.timeScale = 0f;
            Debug.Log("jikann" + Time.timeScale);
        }
        if (paused == false)
        {
            Time.timeScale = 1f;
        }
    }
}
