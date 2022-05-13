using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntCombat : Stats{
    public HealthBar healthBar;

    void Start(){
        healthBar = GameObject.Find("Health bar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(health);
    }
    public override void TakeDamage(int Dmg){
        if(Dmg - armor > 0){
            health -= Dmg - armor;
        } else {
            health -= 1;
        }
        healthBar.SetHealth(health);
        if(health <= 0 )
            Death();
    }
    public override void Death(){
        Debug.Log("just act like you did something like opening a end screen or something");
    }
}
