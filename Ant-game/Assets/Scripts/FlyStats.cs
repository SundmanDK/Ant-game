using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyStats : Stats{

    public GameObject bossManage;
    
    protected override void Death(){
        Destroy(transform.parent.gameObject);
        bossManage.GetComponent<BossManage>().updateBossCount();
    }

    public override void TakeDamage(int Dmg){
        if (Random.Range(0,4) < 3){
            base.TakeDamage(Dmg);
        }
    }
    
}
