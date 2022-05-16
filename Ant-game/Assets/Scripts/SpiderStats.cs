using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderStats : Stats{
    void FixedUpdate(){
        AttackTimer();
    }

    public override void TakeDamage(int Dmg){
        base.TakeDamage(Dmg);
    }
}
