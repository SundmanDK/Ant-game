using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Stats{
    public GameObject bossManage;
    public GameObject Ant;

    protected override void Death(){
        Destroy(transform.parent.gameObject);
        bossManage.GetComponent<BossManage>().updateBossCount();
    }    
}
