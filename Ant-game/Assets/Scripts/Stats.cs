using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Stats : MonoBehaviour{
    public int health;
    public int armor;
    public float attackSpeed;
    public int damage;
    public int targetLayer;
    private float timeForAttack;
    private bool readyForAttack = true;


    public GameObject dmgText;
    private string numberText;
    

    void FixedUpdate(){
      //  Debug.Log("X");
        AttackTimer();
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
    void AttackTimer(){
        if(!readyForAttack){
            timeForAttack += Time.deltaTime;
            if (timeForAttack > attackSpeed){
                readyForAttack = true;
            }
        }
    }
    void Attack(Collision2D target){
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
    protected virtual void Death(){
        Destroy(transform.parent.gameObject);
    }
    void killWorkerAnts(Collision2D target){
        Destroy(target.gameObject);
    }



public void CallDamangeVisual()
{
        numberText = damage.ToString();
        dmgText.GetComponentInChildren<TextMeshPro>().text = numberText;
        dmgText.GetComponent<SpawnDmgText>().PrintDmg();
     
        





    }



}