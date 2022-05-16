using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderStats : Stats{
    public override void TakeDamage(int Dmg){
        base.TakeDamage(Dmg);
    }
    
    public override void Death(){
        Destroy(transform.parent.gameObject);
    }
}
