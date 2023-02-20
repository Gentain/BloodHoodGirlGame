using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectCursor : MonoBehaviour
{
    const int xButtons = 3;
    const int yButtons = 2;
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
        buttonObj[0, 0] = GameObject.Find("/Canvas/Level1");
        selected[0, 0] = true;
        buttonObj[1, 0] = GameObject.Find("/Canvas/Level2");
        buttonObj[2, 0] = GameObject.Find("/Canvas/Level3");
        for (int i = 0; i < xButtons; i++)
        {
                buttonObj[i, yButtons - 1] = GameObject.Find("/Canvas/BackButton");
        }
    }

    // Update is called once per frame
    void Update()
    {
        input_x = Input.GetAxis("CrossHori_");
        input_y = Input.GetAxis("CrossVert_");
        if (movingStopper == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || input_y >= inputForce)
            {
                y--;
                if (y < 0)
                {
                    y = yButtons - 1;
                }
                movingStopper = true;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || input_y <= -inputForce)
            {
                y++;
                if (y >= yButtons)
                {
                    y = 0;
                }
                movingStopper = true;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || input_x >= inputForce)
            {
                x++;
                if (x >= xButtons)
                {
                    x = 0;
                }
                movingStopper = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || input_x <= -inputForce)
            {
                x--;
                if (x < 0)
                {
                    x = xButtons - 1;
                }
                movingStopper = true;
            }
        }
        else if (movingStopper == true)
        {
            if (input_x <= 0 && input_y <= 0)
            {
                movingStopper = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 1"))
        {
            if (x == 0 && y == 0)
            {
                SceneManager.LoadScene("Scenes/Level1");
            }
            else if (x == 1 && y == 0)
            {
                SceneManager.LoadScene("Scenes/Level2");
            }
            else if (x == 2 && y == 0)
            {
                SceneManager.LoadScene("Scenes/Level3");
            }
            else if (y == 1)
            {
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
        Debug.Log("(" + x + "," + y + ")");
        RectTransform buttonRectTransform = buttonObj[x, y].GetComponent<RectTransform>();
        float buttonSize_x = buttonRectTransform.sizeDelta.x;
        transform.position = buttonObj[x, y].transform.position + new Vector3(-buttonSize_x / 2 - 30, 0f, 0f);
    }
}
