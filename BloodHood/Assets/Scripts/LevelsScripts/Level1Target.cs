using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Target : MonoBehaviour
{
    public static int targetKills;
    int allTargets;

    // Start is called before the first frame update
    void Start()
    {

        targetKills = 0;
        allTargets = 4;
        LevelCounter.currentLevel = 0;
        MissionClear.missionClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        Text uiText = GetComponent<Text>();
        if (targetKills < allTargets)
        {
            uiText.text = "" + targetKills + "/" + allTargets;
        }
        else if (targetKills >= allTargets)
        {
            uiText.text = "Clear!";
            MissionClear.missionClear = true;
        }
    }
}
