using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderStats : Stats{
    private float slowCooldown = 10;
    public bool slowOnCooldown = false;
    private float timeOnCooldown;

    protected override void Attack(Collision2D target){
        base.Attack(target);
        if(!slowOnCooldown){
            ApplySlow(target);
        }
    }
    private void ApplySlow(Collision2D target){
        target.gameObject.GetComponent<Stats>().SlowedSpeed();
        slowOnCooldown = true;
    }
    void FixedUpdate(){
        if (health <= 0)
        {
            Death();
        }
        AttackTimer();
        if(slowOnCooldown){
            timeOnCooldown += Time.deltaTime;
            if (timeOnCooldown > slowCooldown){
                slowOnCooldown = false;
                timeOnCooldown = 0;
            }
        }
    }
}
