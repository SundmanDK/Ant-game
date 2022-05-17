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

    public string numberText;
    public GameObject dmgText;

    void FixedUpdate(){
        AttackTimer();
        if(slowedSpeed){
            slowTimer += Time.deltaTime;
            if (slowTimer > slowedTime){
                NormalSpeed();
            }
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

    private void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.layer == targetLayer && readyForAttack){
            Debug.Log("hit");
            if (target.gameObject.GetComponent<Stats>() != null){ //Check if target is a combatant or a worker, relevant for enemies.
                Attack(target);
                timeForAttack = 0;
                readyForAttack = false;
            } else {
                killWorkerAnts(target);
                Debug.Log(target.gameObject.layer +" this!!!!!!!!!!!!!!!");
            }
        }
    }

    protected virtual void Attack(Collision2D target){
        target.gameObject.GetComponent<Stats>().TakeDamage(damage);
        CallDamangeVisual();
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



    protected virtual void Death(){
        Destroy(transform.parent.gameObject);
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
