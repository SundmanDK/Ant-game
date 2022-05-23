using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntCombat : Stats{
    public HealthBar healthBar;
    public GameObject InitializeGameover;
    private Camera cam;
    public int maxHealth;
    public bool poisonUnlocked = false;
    private float poisonCooldown = 10;
    public bool poisonOnCooldown = false;
    private float timeOnCooldown;


    void Start(){
        maxHealth = health;
        healthBar = GameObject.Find("Health bar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(health);
        healthBar.SetHealth(health);
        cam = Camera.main;
    }

    void FixedUpdate(){
        AttackTimer();
        SlowedTimer();
        PoisonTimer();
        
        if(health <= 0){
            Death();
        }
        if(poisonOnCooldown && poisonUnlocked){
            timeOnCooldown += Time.deltaTime;
            if (timeOnCooldown > poisonCooldown){
                poisonOnCooldown = false;
                timeOnCooldown = 0;
            }
        }
    }

    protected override void Attack(Collision2D target){
        base.Attack(target);
        if(!poisonOnCooldown && poisonUnlocked){
            ApplyPoison(target);
        }
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

    private void ApplyPoison(Collision2D target){
        target.gameObject.GetComponent<Stats>().Poison(damage/4);
        poisonOnCooldown = true;
    }
}
