using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour{
    private Rigidbody2D rigidbodyComponent;
    public float moveSpeed = 6;
    public GameObject food;
    private Rigidbody2D rigidbodyComponentChild;
    public bool holdingFood;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    FieldOfView fow;
    RandomDirection randDirection;
    List<Transform> targets;
    public Transform target;
    public float angle;
    int steps;

    // Start is called before the first frame update
    void Start(){
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        fow = GetComponent<FieldOfView>();
        randDirection = GetComponent<RandomDirection>();
        targets = fow.visibleTargets;
        holdingFood = false;
    }

    void ChangeSprite(){
        spriteRenderer.sprite = newSprite;
    }

    // Update is called once per frame
    void Update(){

    }
    // Update is called once per phycis update 
    void FixedUpdate(){
        angle = 0;

        if (targets.Count > 0){ 
            target = randDirection.Pick(targets);
            Vector3 directionToTarget = (target.position - transform.position);
            angle = Vector3.Angle(transform.up, directionToTarget);
            if (angle > fow.viewAngle/2){
                angle = 0;
            }
            Debug.Log("Angle: "+angle); 
        } else {
            int chooseMove = Random.Range(1, 4);
            if (chooseMove == 1) {
                angle = -10f;
            } else if (chooseMove == 2){
                angle = 10f;
            }
        }
        
        transform.RotateAround(transform.position, transform.forward, angle);
        rigidbodyComponent.velocity = transform.up * moveSpeed;
        steps++;
    }

    /*
    void OnCollisionEnter2D(Collision2D collision2D){
        transform.RotateAround(transform.position, transform.forward, 180f);

    }
    
    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.layer == 6 && holdingFood == false){
            Destroy(col.gameObject);
            holdingFood = true;
            Debug.Log("mr. ant is holding food");
            ChangeSprite();
            transform.RotateAround(transform.position, transform.forward, 180f);
        }
    }
    */

}
