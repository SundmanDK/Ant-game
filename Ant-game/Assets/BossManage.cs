using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManage : MonoBehaviour
{
    int childCount;
    int newChildCount;
    void Start()
    {
        childCount = 0;
        foreach (Transform child in transform)
        {
            childCount++;
           
        }
        Debug.Log(childCount);
    }


  public void updateBossCount()
    {

        childCount = childCount - 1;
        if (childCount==0) { Victory(); }
        Debug.Log(childCount);
    }

    void Victory()
    {
        Debug.Log(" You won! Amazing!!!");
    }
}
