using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManage : MonoBehaviour
{
   
    public GameObject InitializeGameover;
    public List<GameObject> bosses = new List<GameObject>();

    public void updateBossCount()
    {
        bosses.RemoveAt(0);
        if (bosses.Count <= 1) { Victory(); }
    }


    public void Victory()
    {
        InitializeGameover.GetComponent<GameoverInitializeScript>().Win();

    }
}
