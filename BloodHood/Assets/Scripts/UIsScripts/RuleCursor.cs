using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RuleCursor : MonoBehaviour
{
    const int xButtons = 1;
    const int yButtons = 1;
    public GameObject[,] buttonObj = new GameObject[xButtons, yButtons];
    bool[,] selected = new bool[xButtons, yButtons];
    int x, y;
    float input_x, input_y;
    float inputForce = 1f;
    bool movingStopper;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        y = 0;
        input_x = 0;
        input_y = 0;
        movingStopper = false;
        for (int i = 0; i < xButtons; i++)
        {
            for (int j = 0; j < yButtons; j++)
            {
                selected[i, j] = false;
            }
        }
        buttonObj[0, 0] = GameObject.Find("/Canvas/BackButton");
        selected[0, 0] = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 1"))
        {
            if (x == 0 && y == 0)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene("Scenes/MenuScene");
            }
        }
        for (int i = 0; i < xButtons; i++)
        {
            for (int j = 0; j < yButtons; j++)
            {
                selected[i, j] = false;
            }
        }
        selected[x, y] = true;
        RectTransform buttonRectTransform = buttonObj[x, y].GetComponent<RectTransform>();
        float buttonSize_x = buttonRectTransform.sizeDelta.x;
        transform.position = buttonObj[x, y].transform.position + new Vector3(-buttonSize_x / 2 - 30, 0f, 0f);
    }
    
}


