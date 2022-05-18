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
    public string numberText;
    public GameObject dmgText;
    public GameObject bossManage;
   

    void FixedUpdate(){
        AttackTimer();
        SlowedTimer();
        PoisonTimer();
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
        if(slowedSpeed){
            slowTimer += Time.deltaTime;
            if (slowTimer > slowedTime){
                NormalSpeed();
            }
        }
    }
    protected void PoisonTimer(){
        if(poisoned){
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

    private void TakeTrueDamage(int Dmg){
        health -= Dmg;
        CallDamangeVisual();
    }

    public virtual void TakeDamage(int Dmg){
        if(Dmg - armor > 0){
            health -= Dmg - armor;
        } else {
            health -= 1;
        }
        CallDamangeVisual();
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
        bossManage.GetComponent<BossManage>().updateBossCount();
    }

    private void killWorkerAnts(Collision2D target){
        Destroy(target.gameObject);
        Debug.Log("target: "+target);
    }

    public void CallDamangeVisual()
    {
        numberText = damage.ToString();
        dmgText.GetComponentInChildren<TextMeshPro>().text = numberText;
        dmgText.GetComponent<SpawnDmgText>().PrintDmg();
    }
}
