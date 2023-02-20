using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSystem : MonoBehaviour
{
    public GameObject resultUI;
    public AudioClip clearSE;
    bool beeped;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        resultUI.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        beeped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (MissionClear.missionClear == true)
        {
           if(beeped == false)
            {
                audioSource.PlayOneShot(clearSE);
                beeped = true;
            }
            resultUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (MissionClear.missionClear == false)
        {
            resultUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
