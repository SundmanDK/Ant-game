using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleStats : Enemies{
    
    public override void TakeDamage(int Dmg){
        if(Dmg - armor > 0){
            actualDamage = Dmg - armor;
        } else {
            actualDamage = 0;
        }
        health -= actualDamage;
        CallDamangeVisual(actualDamage.ToString());
    }

    protected override void Death(){
        Ant.GetComponent<AntCombat>().armor += 20;
        base.Death();
    }

}
