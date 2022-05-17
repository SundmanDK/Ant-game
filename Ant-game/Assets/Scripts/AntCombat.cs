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
        base.TakeDamage(Dmg);
        healthBar.SetHealth(health);
    }

    protected override void Death(){
        Destroy(gameObject);
        InitializeGameover.gameObject.SetActive(true);
    }
}
