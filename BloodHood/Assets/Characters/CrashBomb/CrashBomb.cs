using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class CrashBomb : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Utils.ForceCrash(ForcedCrashCategory.FatalError);
        }
    }
}
