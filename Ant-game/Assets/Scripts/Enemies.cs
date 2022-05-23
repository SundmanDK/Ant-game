using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Stats{
    public GameObject bossManage;
    public GameObject Ant;
    public GameObject nest;
    protected NestStorage NS;

    void Start(){
        NS = nest.GetComponent<NestStorage>();
    }

    protected override void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.layer == targetLayer && readyForAttack){
            if (target.gameObject.GetComponent<Stats>() != null){ //Check if target is a controllableAnt or a worker
                Attack(target);
                timeForAttack = 0;
                readyForAttack = false;
            } else {
                killWorkerAnts(target);
            }
        }
    }

    private void killWorkerAnts(Collision2D target){
        Destroy(target.gameObject);
        NS.antDiedDecreaseCost();
    }

    protected override void Death(){
        Destroy(transform.parent.gameObject);
        bossManage.GetComponent<BossManage>().updateBossCount();
        NS.killedBosses += 1;
        NS.IncreasedIncome();
        NS.showStats();
    }    
}
