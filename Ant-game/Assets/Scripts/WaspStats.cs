using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspStats : Stats{

    float chargeTimer = 0; 

    void FixedUpdate(){
        Debug.Log("y");

    }

    public override void TakeDamage(int Dmg){
        base.TakeDamage(Dmg);
    }

}
