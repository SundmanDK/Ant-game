using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntCombat : Stats{
    public HealthBar healthBar;
    public GameObject InitializeGameover;
    private Camera cam;
    public int maxHealth;


    void Start(){
        maxHealth = health;
        healthBar = GameObject.Find("Health bar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(health);
        cam = Camera.main;
    }

    public void heal(int hp){
        health += hp;
        
        if (health > maxHealth){
            health = maxHealth;
        }
        healthBar.SetHealth(health);
    }

    protected override void TakeTrueDamage(int Dmg){
        base.TakeTrueDamage(Dmg);
        healthBar.SetHealth(health);
    }

    public override void TakeDamage(int Dmg){
        base.TakeDamage(Dmg);
        healthBar.SetHealth(health);
    }

    protected override void Death(){
        Destroy(gameObject);
        InitializeGameover.GetComponent<GameoverInitializeScript>().Lost();
    }
}
