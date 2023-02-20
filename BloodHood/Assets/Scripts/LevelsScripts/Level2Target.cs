using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Target : MonoBehaviour
{
    public static int targetKills;
    int allTargets;

    // Start is called before the first frame update
    void Start()
    {
        targetKills = 0;
        allTargets = 1;
        LevelCounter.currentLevel = 1;
        MissionClear.missionClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("☆：" + LevelCounter.currentLevel);
        Text uiText = GetComponent<Text>();
        if (targetKills < allTargets)
        {
            uiText.text = "" + targetKills + "/" + allTargets;
        }
        else if (targetKills >= allTargets)
        {
            uiText.text = "Clear!";
            Time.timeScale = 0.0f;
            MissionClear.missionClear = true;
        }
    }
}