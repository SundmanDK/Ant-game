using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspStats : Stats{

    float chargeTimer = 0; 

    override void FixedUpdate(){
        base.FixedUpdate();

    }

    public override void TakeDamage(int Dmg){
        base.TakeDamage(Dmg);
    }

}
