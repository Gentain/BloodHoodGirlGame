using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LevelCounter;

public class AllResults : MonoBehaviour
{
    public int level = 0;
    int allLevel = 3;
    public const int allRank = 5;
    float[,] recordTime = new float[LevelCounter.maxLevel, allRank];
    public Text[] bestTime = new Text[allRank];
    float extraBox;
    public Text levelText;
    float input_x;
    float inputForce = 1f;
    bool movingStopper;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < allRank; i++)
        {
            if (PlayerPrefs.HasKey("recordTime[" + level + "][" + i + "]"))
            {
                recordTime[level, i] = PlayerPrefs.GetFloat("recordTime[" + level + "][" + i + "]");
            }
            else
            {
                recordTime[level, i] = 999;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < allRank; i++)
        {
            if (PlayerPrefs.HasKey("recordTime[" + level + "][" + i + "]"))
            {
                recordTime[level, i] = PlayerPrefs.GetFloat("recordTime[" + level + "][" + i + "]");
            }
            else
            {
                recordTime[level, i] = 999;
            }
        }

        for (int i = allRank - 1; i >= 0; i--)
        {
            bestTime[i].text = "" + recordTime[level, i];
        }

        input_x = Input.GetAxis("CrossHori_");
        movingStopper = false;
        if (movingStopper == false)
        {
            if ((Input.GetKeyDown(KeyCode.LeftArrow) || input_x <= -inputForce) && level > 0)
            {
                level--;
                movingStopper = true;
            }
            if ((Input.GetKeyDown(KeyCode.RightArrow) || input_x >= inputForce) && level < allLevel - 1)
            {
                level++;
                movingStopper = true;
            }
        }
        else if (movingStopper == true)
        {
            if (input_x <= 0)
            {
                movingStopper = false;
            }
        }

        levelText.text = "Level:" + (level + 1);
    }
}

