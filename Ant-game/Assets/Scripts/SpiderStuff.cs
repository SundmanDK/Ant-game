using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderStuff : MonoBehaviour
{
    private Rigidbody2D rigidbodyComponent;
    private float moveSpeed;
    public bool inArea;
    private CombatFieldOfView fow;
    private Stats stats;
    
    void Start(){
        inArea = true;
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        fow = GetComponent<CombatFieldOfView>();
        stats = GetComponent<Stats>();
        moveSpeed = stats.moveSpeed;
    }

    
    void FixedUpdate(){
        move();
        if(inArea){
            followAnt();
        } else if (!inArea){
            goHome();
        }
    }

    void move(){
        rigidbodyComponent.velocity = transform.up * moveSpeed;
    }
    private void followAnt(){
        if (fow.visibleTargets.Count > 0){
            Transform target = fow.visibleTargets[0];
            if(target != null){
                Vector3 directionToTarget = (target.transform.position - transform.position).normalized;
                float angle = Vector3.Angle(transform.up, directionToTarget);
                transform.RotateAround(transform.position, transform.forward, angle);
            }
        } else{
            transform.RotateAround(transform.position, transform.forward, Random.Range(-5f,5f));
        }
    }
    private void goHome(){
        Transform home = transform.parent;
        Vector3 directionToTarget = (home.transform.position - transform.position).normalized;
        float angle = Vector3.Angle(transform.up, directionToTarget);
        transform.RotateAround(transform.position, transform.forward, angle);
    }

    void OnCollisionEnter2D(Collision2D collision2D){
        if (collision2D.gameObject.layer == 7){
            transform.RotateAround(transform.position, transform.forward, 90f);
        }
    }
}
