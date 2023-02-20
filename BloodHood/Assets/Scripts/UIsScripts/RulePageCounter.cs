using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulePageCounter : MonoBehaviour
{
    const int allPages = 6;
    public GameObject[] pageObject = new GameObject[allPages];
    int page;
    public Text pageText;
    float input_x;
    float inputForce = 1f;
    bool movingStopper;

    // Start is called before the first frame update
    void Start()
    {
        movingStopper = false;
        pageText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        input_x = Input.GetAxis("CrossHori_");
        movingStopper = false;
        if (movingStopper == false)
        {
            if ((Input.GetKeyDown(KeyCode.LeftArrow) || input_x <= -inputForce) && page > 0)
            {
                page--;
                movingStopper = true;
            }
            if ((Input.GetKeyDown(KeyCode.RightArrow) || input_x >= inputForce) && page < allPages - 1)
            {
                page++;
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
        for (int i = 0; i < allPages; i++)
        {
            if (i == page)
            {
                pageObject[i].SetActive(true);
            }
            else
            {
                pageObject[i].SetActive(false);
            }
        }
        pageText.text = "" + (page + 1) + "/" + allPages;
    }
}
