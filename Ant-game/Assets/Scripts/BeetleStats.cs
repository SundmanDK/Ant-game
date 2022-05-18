using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleStats : Stats
{
    public virtual void TakeDamage(int Dmg){
        if(Dmg - armor > 0){
            health -= Dmg - armor;
        }
        CallDamangeVisual();
    }
}
