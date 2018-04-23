﻿/** 
 * 这个类是用来记录玩家得分的 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecorder : MonoBehaviour
{

    /** 
     * score是玩家得到的总分 
     */

    public int score;

    /** 
     * scoreTable是一个得分的规则表，每种飞碟的颜色对应着一个分数 
     */

    private Dictionary<Color, int> scoreTable = new Dictionary<Color, int>();

    // Use this for initialization  
    void Start()
    {
        score = 0;
        scoreTable.Add(Color.yellow, 1);
        scoreTable.Add(Color.red, 2);
        scoreTable.Add(Color.black, 4);
        scoreTable.Add(Color.blue, 8);
    }

    public void Record(GameObject disk)
    {
        //print(disk.GetComponent<DiskData>().color);
        // print(Color.yellow);
        score += scoreTable[disk.GetComponent<DiskData>().color];
    }

    public void Reset()
    {
        score = 0;
    }

    public void miss() //扣分  
    {
        score -= 1;
    }
}