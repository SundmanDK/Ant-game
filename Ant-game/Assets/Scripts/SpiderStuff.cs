using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderStuff : MonoBehaviour
{
    private Rigidbody2D rigidbodyComponent;
    public float moveSpeed = 8;
    public bool inArea;
    private EnemyFieldOfView fow;
    // Start is called before the first frame update
    void Start(){
        inArea = true;
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        fow = GetComponent<EnemyFieldOfView>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        move();
        if(inArea){
            followAnt();
        } else{
            goHome();
        }
    }

    void move(){
        rigidbodyComponent.velocity = transform.up * moveSpeed;
    }
    private void followAnt(){
        if (fow.visibleTargetsMid.Count > 0){
            Transform target = fow.visibleTargetsMid[0];
            Vector3 directionToTarget = (target.transform.position - transform.position).normalized;
            float angle = Vector3.Angle(transform.up, directionToTarget);
            transform.RotateAround(transform.position, transform.forward, angle);
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
