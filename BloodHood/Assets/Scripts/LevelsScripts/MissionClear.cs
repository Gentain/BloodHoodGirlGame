using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionClear : MonoBehaviour
{
    static public bool missionClear;
    // Start is called before the first frame update
    void Start()
    {
        missionClear = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void ClearFlagDelete()
    {
        missionClear = false;
    }
}
