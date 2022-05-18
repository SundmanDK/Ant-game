using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManage : MonoBehaviour
{
   
    public GameObject InitializeGameover;
    public Stats[] enemies;
    private int statIncrease = 5;
    public List<GameObject> bosses = new List<GameObject>();

    public void updateBossCount(){
        bosses.RemoveAt(0);
        if (bosses.Count <= 1) { Victory(); }
        Debug.Log("dead boss");
        statIncrease += 5;
        enemies = GetComponentsInChildren<Stats>();
        foreach(Stats stats in enemies){
            stats.damage += statIncrease;
            stats.health += statIncrease;
            stats.armor += statIncrease;
        }
    }


    public void Victory()
    {
        InitializeGameover.GetComponent<GameoverInitializeScript>().Win();

    }
}
