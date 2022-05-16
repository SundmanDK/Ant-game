using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntCombat : Stats{
    public HealthBar healthBar;
    public GameObject InitializeGameover;
    private Camera cam;

    void Start(){
        healthBar = GameObject.Find("Health bar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(health);
        cam = Camera.main;
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
        InitializeGameover.gameObject.SetActive(true);
        
    }
}
