using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isStart = false;
    public static int isPause = -1;
    public static int SpaceNum = 0;
    public static int change = 0;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpaceNum++;
            switch (isPause)
            {
                case -1:
                    isPause = 1;
                    break;
                case 0:
                    isPause = 1;
                    break;
                case 1:
                    isPause = 0;
                    break;
            }

            Debug.Log("GM Time.time: " + Time.time);
        }

        if (isPause == 0)
        {
            Time.timeScale = 1;
        } else if (isPause == 1)
        {
            Time.timeScale = 0;
        } else if (isPause == 2)
        {
            Time.timeScale = 0;
        }
    }

}
