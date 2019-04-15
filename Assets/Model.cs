using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    // params of the valid map 
    public const int MAX_ROWS = 5;
    public const int MAX_COLUMNS = 5;
    public static Transform[,] map = new Transform[MAX_COLUMNS,MAX_ROWS + 1];

    // params of the HUD
    public static int HitNum = 0;
    public static int RNum = 0;
    public static int GNum = 0;
    public static int BNum = 0;
    public static int HorNum = 0;
    public static int totalNum = 0;
    public static int score = 0;
    

    // check whether map contains groupd particles 
    public static void checkMap()
    {

        checkVertical();
        checkHorizontal();
    }

    // check game over state
    public static int checkWinOrLose()
    {

        if (checkDebris() >= 5  ){ return -1; }
        else if (checkMapFilled()) { return -2; }
        else if (score >= 100) {  return 1; }
        else { return 0; }
    }


    // check whether map contains verticle groupd particles
    private static void checkVertical()
    {
            for (int i = 0; i < MAX_COLUMNS; i++)
            {
                for (int j = 0; j < MAX_ROWS - 2; j++)
                {
                    if (map[i, j] != null && map[i, j + 1] != null && map[i, j + 2] != null)
                    {
                        if (map[i, j].name == map[i, j + 1].name && map[i, j].name == map[i, j + 2].name && map[i,j].tag != "Debris") 
                        {
                        switch (map[i, j].name.Trim())
                        {
                            case "Red(Clone)":
                                RNum++;
                                break;
                            case "Green(Clone)":
                                GNum++;
                                break;
                            case "Blue(Clone)":
                                BNum++;
                                break;
                        }
                        // Destroy the group and update
                            Destroy(map[i, j].gameObject);
                            Destroy(map[i, j + 1].gameObject);
                            Destroy(map[i, j + 2].gameObject);
                            map[i, j] = null;
                            map[i, j + 1] = null;
                            map[i, j + 2] = null;
                            totalNum++;
                            score = score + 10;
                        }
                    }

                }
            }
    }

    // check whether map contains horizontal groupd particles
    private static void checkHorizontal()
    {
        for (int i = 0; i < MAX_COLUMNS; i++)
        {
            
            for (int j = 0; j < MAX_COLUMNS - 2; j++)
            {
                if (map[j, i] != null && map[j + 1, i] != null && map[j + 2, i] != null)
                {
                    if (map[j, i].name.Trim() == "Red(Clone)" && map[j + 1, i].name.Trim() == "Green(Clone)" && map[j + 2, i].name.Trim() == "Blue(Clone)")
                    {
                        // Destroy the group and update
                        Destroy(map[j, i].gameObject);
                        Destroy(map[j + 1, i].gameObject);
                        Destroy(map[j + 2, i].gameObject);
                        map[j, i] = null;
                        map[j + 1, i] = null;
                        map[j + 2, i] = null;
                        HorNum++;
                        totalNum++;
                        Debug.Log("HorNum: " + HorNum);
                        score = score + 15;
                        if (i != 4)
                        {
                            decreaseRow(j, i);
                            checkMap();
                        }

                    }
                }
            }
        }
    }

    // update map after destroying horizontal groupd particles
    private static void decreaseRow(int x, int y)
    {
        for (int i = x; i < x + 3; i++)
        {
            for (int j = y; j < MAX_ROWS; j++)
            {
                if (map[i, j] != null) {
                    map[i, j].position += new Vector3(0, -1, 0);
                    map[i, j - 1] = map[i, j];
                    map[i, j] = null;
                }
            }
        }
    }

    // check the number of debris in the storage area
    private static int checkDebris()
    {
        int DebrisNum = 0;
        for (int i = 0; i < MAX_ROWS; i++)
        {
            for (int j = 0; j < MAX_COLUMNS; j++)
            {
                if (map[i, j] != null && map[i,j].tag == "Debris")
                {
                    DebrisNum++;
                }
            }
        }

        return DebrisNum;
    }

    // check the storage area is filled with non-lined ionised particles
    private static bool checkMapFilled()
    {
            for (int i = 0; i < MAX_COLUMNS; i++)
            {
                if (map[i, 5] != null)
                {
                    return true;
                }
            }
         return false;  
    }
}




