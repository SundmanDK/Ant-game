using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspStats : Enemies{
    private float chargeCooldown = 10;
    public bool chargeOnCooldown = false;
    private float timeOnCooldown = 0;
    private SpiderStuff behaviour;
    private float timeRemaining = 2;
    private float startSpeed;
    private bool endCharge;

    void Start(){
        NS = nest.GetComponent<NestStorage>();
        behaviour = GetComponent<SpiderStuff>();
        startSpeed = moveSpeed;
    }

    void FixedUpdate(){
        AttackTimer();
        PoisonTimer();
        if(health <= 0){
            Death();
        }
        
        if(behaviour.followingAnt){
            Charge();
        }
        if(chargeOnCooldown){
            timeOnCooldown += Time.deltaTime;
            if(timeRemaining > timeOnCooldown && endCharge == false){
                ChargeAction();
                }
            if (timeOnCooldown > chargeCooldown){
                chargeOnCooldown = false;
                timeOnCooldown = 0;
            }
        }
    }
        
    private void ChargeAction(){
        moveSpeed = 30;
    }
    private void Charge(){
        moveSpeed = startSpeed;
        chargeOnCooldown = true;
    }
    protected override void Attack(Collision2D target){
        base.Attack(target);
        moveSpeed = startSpeed;
        endCharge = true;
    }

    protected override void Death(){
        Ant.GetComponent<AntCombat>().moveSpeed += 5;
        base.Death();
    }
}

