using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleStats : Stats
{
    public override void TakeDamage(int Dmg){
        if(Dmg - armor > 0){
            actualDamage = Dmg - armor;
        } else {
            actualDamage = 0;
        }
        CallDamangeVisual(actualDamage.ToString());
    }
}
