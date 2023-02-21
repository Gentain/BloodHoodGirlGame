using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LevelCounter;

public class AllResults : MonoBehaviour
{
    public int level = 0;   // (現在のレベル数)から-1した数字。配列と取り扱う都合上実数字から-1している。
    int allLevel = 3;   // 全てのレベル数
    public const int allRank = 5;   // 記録するスコア数
    
    // (全レベル数)*(スコアの記録数)の個数分、スコアの記録場所を作る。
    float[,] recordTime = new float[LevelCounter.maxLevel, allRank]; 

    public Text[] bestTime = new Text[allRank];
    float extraBox; // ソート用の変数
    public Text levelText; // レベル数のテキスト
    float input_x;
    float inputForce = 1f;
    bool movingStopper; // ボタンを押した際に見たい面のスコアを見過ごさない為のストッパー

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

