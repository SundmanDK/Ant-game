using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour{
    private Rigidbody2D rigidbodyComponent;
    public float moveSpeed = 6;

    // Start is called before the first frame update
    void Start(){
        rigidbodyComponent = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){

    }
    // Update is called once per phycis update
    void FixedUpdate(){
        rigidbodyComponent.velocity = transform.up * moveSpeed;
        int chooseMove = Random.Range(1, 4);
        if (chooseMove == 1) {
            transform.RotateAround(transform.position, transform.forward, -10f);
        } else if (chooseMove == 3) {
            transform.RotateAround(transform.position, transform.forward, 10f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D){
        transform.RotateAround(transform.position, transform.forward, 180f);

    }

}
