using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeStats : Enemies{

    private float poisonCooldown = 10;
    public bool poisonOnCooldown = false;
    private float timeOnCooldown;

    void FixedUpdate(){
        AttackTimer();
        SlowedTimer();
        PoisonTimer();
        if(health <= 0){
            Death();
        }
        if(poisonOnCooldown){
            timeOnCooldown += Time.deltaTime;
            if (timeOnCooldown > poisonCooldown){
                poisonOnCooldown = false;
                timeOnCooldown = 0;
            }
        }
    }

    protected override void Attack(Collision2D target){
        base.Attack(target);
        if(!poisonOnCooldown){
            ApplyPoison(target);
        }
    }
    private void ApplyPoison(Collision2D target){
        target.gameObject.GetComponent<Stats>().Poison(damage/4);
        poisonOnCooldown = true;
    }

}
