using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleStats : Stats
{

    public GameObject bossManage;
    
    public override void TakeDamage(int Dmg){
        if(Dmg - armor > 0){
            health -= Dmg - armor;
        }
        CallDamangeVisual();
    }

    protected override void Death(){
        Destroy(transform.parent.gameObject);
        bossManage.GetComponent<BossManage>().updateBossCount();
    }
}
