using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static LevelCounter;

public class TimeRecords : MonoBehaviour
{
    int level = 0;
    int rank = 0;
    public const int allRank = 5;
    float[,] record = new float[LevelCounter.maxLevel, allRank];
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        level = LevelCounter.currentLevel;
        for (int i = 0; i < allRank; i++)
        {
            if (PlayerPrefs.HasKey("record[" + level + "][" + rank + "]"))
            {

            }
            else {  }
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("record[" + level + "][" + rank + "]", 999);
    }
}
