using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderStats : Stats{
    private float slowCooldown = 10;
    public bool slowOnCooldown = false;
    private float timeOnCooldown;

    void Update(){
        if(slowOnCooldown){
            timeOnCooldown += Time.deltaTime;
            if (timeOnCooldown > slowCooldown){
                slowOnCooldown = false;
                timeOnCooldown = 0;
            }
        }
    }
    public override void TakeDamage(int Dmg){
        base.TakeDamage(Dmg);
    }
    
    public override void Death(){
        Destroy(transform.parent.gameObject);
    }
    public override void Attack(Collision2D target){
        target.gameObject.GetComponent<Stats>().TakeDamage(damage);
        if(!slowOnCooldown){
            ApplySlow(target);
        }
    }
    private void ApplySlow(Collision2D target){
        target.gameObject.GetComponent<Stats>().SlowedSpeed();
        slowOnCooldown = true;
    }
}
