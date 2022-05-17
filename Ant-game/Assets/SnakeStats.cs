using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeStats : Stats{

    private float poisonCooldown = 10;
    public bool poisonOnCooldown = false;
    private float timeOnCooldown;
    protected override void Attack(Collision2D target){
        base.Attack(target);
        if(!poisonOnCooldown){
            ApplyPoison(target);
        }
    }
    private void ApplyPoison(Collision2D target){
        target.gameObject.GetComponent<Stats>().Poison();
        poisonOnCooldown = true;
    }

}
