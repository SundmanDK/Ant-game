using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Stats : MonoBehaviour{
    public int health;
    public int armor;
    public float attackSpeed;
    public int damage;
    public float moveSpeed;
    public int targetLayer;
    private float timeForAttack;
    private bool readyForAttack = true;
    private bool slowedSpeed = false;
    private float slowTimer;
    private float slowedTime = 4;
    private int poisonDmg;
    private bool poisoned;
    private float poisonTimer;
    private float poisonTickDuration = 2;
    private int poisonTicks;
    public int actualDamage;
    public GameObject dmgText;   

    void FixedUpdate(){
        AttackTimer();

        if(slowedSpeed){
            SlowedTimer();
        }
        if(poisoned){
            PoisonTimer();
        }
        if(health <= 0){
            Death();
        }
    }

    protected void AttackTimer(){
        if(!readyForAttack){
            timeForAttack += Time.deltaTime;
            if (timeForAttack > attackSpeed){
                readyForAttack = true;
            }
        }
    }
    protected void SlowedTimer(){
        slowTimer += Time.deltaTime;
        if (slowTimer > slowedTime){
            NormalSpeed();
        }
        
    }
    protected void PoisonTimer(){
        poisonTimer += Time.deltaTime;
        if (poisonTimer > poisonTickDuration){
            TakeTrueDamage(poisonDmg);
            poisonTimer = 0;
            poisonTicks += 1;
            if(poisonTicks >= 4){
                poisoned = false;
                poisonTicks = 0;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.layer == targetLayer && readyForAttack){
            if (target.gameObject.GetComponent<Stats>() != null){ //Check if target is a combatant or a worker, relevant for enemies.
                Attack(target);
                timeForAttack = 0;
                readyForAttack = false;
            } else {
                killWorkerAnts(target);
            }
        }
    }

    protected virtual void Attack(Collision2D target){
        target.gameObject.GetComponent<Stats>().TakeDamage(damage);
    }

    protected virtual void TakeTrueDamage(int Dmg){
        health -= Dmg;
        CallDamangeVisual(Dmg.ToString());
    }

    public virtual void TakeDamage(int Dmg){

        if(Dmg - armor > 0){
            actualDamage = Dmg - armor;
        } else {
            actualDamage = 1;
        }
        health -= actualDamage;
        CallDamangeVisual(actualDamage.ToString());
    }
    public void SlowedSpeed(){
        slowTimer = 0;
        if(slowedSpeed == false){
            moveSpeed /= 2;
            slowedSpeed = true;
        }
    }

    private void NormalSpeed(){
        moveSpeed *= 2;
        slowedSpeed = false;
    }

    public void Poison(int incomingPoisonDmg){
        poisonTimer = 0;
        poisonDmg = incomingPoisonDmg;
        if(poisoned == false)
            poisoned = true;
    }

    protected virtual void Death(){
        Destroy(transform.parent.gameObject);
    }

    private void killWorkerAnts(Collision2D target){
        Destroy(target.gameObject);
        Debug.Log("target: "+target);
    }

    public void CallDamangeVisual(string displayText){
        dmgText.GetComponentInChildren<TextMeshPro>().text = displayText;
        dmgText.GetComponent<SpawnDmgText>().PrintDmg();
    }
}
