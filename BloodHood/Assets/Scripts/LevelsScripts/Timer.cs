using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (MissionClear.missionClear == false && PauseSystem.paused == false)
        {
            time += Time.deltaTime;
        }
        int t = Mathf.FloorToInt(time);
        Text timeText = GetComponent<Text>();
        timeText.text = "Time:" + time + "s";
    }
}
