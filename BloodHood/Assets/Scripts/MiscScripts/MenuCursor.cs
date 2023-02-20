using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCursor : MonoBehaviour
{
    const int xButtons = 2;
    const int yButtons = 4;
    public GameObject[,] buttonObj = new GameObject[xButtons, yButtons];
    bool[,] selected = new bool[xButtons, yButtons];
    int x, y;

    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        y = 0;
        for (int i = 0; i < xButtons; i++)
        {
            for (int j = 0; j < yButtons; j++)
            {
                selected[i, j] = false;
            }
        }
        buttonObj[0, 0] = GameObject.Find("/Canvas/MissionSelectButton");
        selected[0, 0] = true;
        buttonObj[0, 1] = GameObject.Find("/Canvas/RuleButton");
        buttonObj[0, 2] = GameObject.Find("/Canvas/ResultButton");
        buttonObj[0, 3] = GameObject.Find("/Canvas/SpecialThanksButton");
        for (int i = 1; i < xButtons; i++)
        {
            for (int j = 0; j < yButtons; j++)
            {
                buttonObj[i, j] = GameObject.Find("/Canvas/BackButton");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (x == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                y--;
                if (y < 0)
                {
                    y = yButtons - 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                y++;
                if (y >= yButtons)
                {
                    y = 0;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x++;
            if (x >= xButtons)
            {
                x = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x--;
            if (x < 0)
            {
                x = xButtons - 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (x == 0 && y == 0)
            {
                SceneManager.LoadScene("Scenes/MissionSelectScene");
            }
            else if (x == 0 && y == 1)
            {
                SceneManager.LoadScene("Scenes/RuleScene");
            }
            else if (x == 0 && y == 2)
            {
                SceneManager.LoadScene("Scenes/ResultScene");
            }
            else if (x == 0 && y == 3)
            {
                SceneManager.LoadScene("Scenes/SpecialThanksScene");
            }
            else if (x == 1)
            {
                SceneManager.LoadScene("Scenes/TitleScene");
            }
        }
        for (int i = 1; i < xButtons; i++)
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
        transform.position = buttonObj[x, y].transform.position + new Vector3( -buttonSize_x / 2 - 30, 0f, 0f) ;
    }
}
