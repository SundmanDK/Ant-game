using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour{
    public int health;
    public int armor;
    public float attackSpeed;
    public int damage;
    public int targetLayer;
    private float timeForAttack;
    private bool readyForAttack = true;

    void FixedUpdate(){
        if(!readyForAttack){
            timeForAttack += Time.deltaTime;
            if (timeForAttack > attackSpeed){
                readyForAttack = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.layer == targetLayer && readyForAttack){
            if (target.gameObject.GetComponent<Stats>() != null){ //Check if target is a combatant or a worker 
                Attack(target);
                readyForAttack = false;
                timeForAttack = 0;
            } else {
                killWorkerAnts(target);
            }
        }
    }
    private void Attack(Collision2D target){
        target.gameObject.GetComponent<Stats>().TakeDamage(damage);
    }
    public virtual void TakeDamage(int Dmg){
        if(Dmg - armor > 0){
            health -= Dmg - armor;
        } else {
            health -= 1;
        }
        if(health <= 0){
            Death();
        }
    }
    public virtual void Death(){
        Destroy(gameObject);
    }
    public virtual void killWorkerAnts(Collision2D target){
        Destroy(target.gameObject);
    }
}
