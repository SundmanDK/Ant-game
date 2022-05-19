using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyStats : Enemies{


    public override void TakeDamage(int Dmg){
        if (Random.Range(0,4) < 3){
            base.TakeDamage(Dmg);
        } else {
            CallDamangeVisual("Miss");
        }
    }
    
}
