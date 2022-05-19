using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeStats : Stats{

    private float poisonCooldown = 10;
    public bool poisonOnCooldown = false;
    private float timeOnCooldown;
    public GameObject bossManage;

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

    protected override void Death(){
        Destroy(transform.parent.gameObject);
        bossManage.GetComponent<BossManage>().updateBossCount();
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
