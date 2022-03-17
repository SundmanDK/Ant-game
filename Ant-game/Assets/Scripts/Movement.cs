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

    // Start is called before the first frame update
    void Start(){
        rigidbodyComponent = GetComponent<Rigidbody2D>();
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
    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.layer == 6 && holdingFood == false){
            Destroy(col.gameObject);
            holdingFood = true;
            Debug.Log("mr. ant is holding food");
            ChangeSprite();
            transform.RotateAround(transform.position, transform.forward, 180f);
        }
    }

}
