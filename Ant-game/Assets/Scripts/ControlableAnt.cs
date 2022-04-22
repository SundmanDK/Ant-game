using UnityEngine;
using System.Collections;

public class ControlableAnt : MonoBehaviour{
    private Rigidbody2D rigidbodyComponent;
    private Rigidbody2D rigidbodyComponentChild;
    private FieldOfView fow;
    private NestStorage NS;
    public SpriteRenderer spriteRenderer;
    public Sprite noFoodSprite;
    public Sprite foodSprite;
    public GameObject food;

    public float moveSpeed = 6;
    private bool holdingFood;
    private bool goTo = false;
    private float angle;
    private Vector3 goToMarker;
    Camera viewCamera;

    void Start(){
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        NS = GetComponentInParent<NestStorage>();
        fow = GetComponent<FieldOfView>();
        viewCamera = Camera.main;
        Physics2D.IgnoreLayerCollision(0,0,true);
        holdingFood = false;
    }




    void Update(){
        if (Input.GetMouseButtonDown(0)){
            goToMarker = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            Vector3 directionToTarget = (goToMarker - transform.position).normalized;
            angle = Vector3.Angle(transform.up, directionToTarget);
            Debug.Log(angle);
            goTo = true;
        }
    }

    void FixedUpdate(){
        if (transform.position != goToMarker && goTo)
            move();
        else if (transform.position == goToMarker)
            goTo = false;

    }

    void move(){
        rigidbodyComponent.velocity = transform.up * moveSpeed;
        transform.RotateAround(transform.position, transform.forward, angle);
    }





    void OnCollisionEnter2D(Collision2D collision2D){
        if (collision2D.gameObject.layer == 7)
            transform.RotateAround(transform.position, transform.forward, 90f);
    }

    void ChangeSprite(){
        if (holdingFood){
            spriteRenderer.sprite = foodSprite;
        }
        else{
            spriteRenderer.sprite = noFoodSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.layer == 6 && !holdingFood){
            Destroy(col.gameObject);
            holdingFood = true;
            Debug.Log("a ant is holding food");
            ChangeSprite();
            transform.RotateAround(transform.position, transform.forward, 180f);
        }
        if(col.gameObject.layer == 8 && holdingFood){
            holdingFood = false;
            NS.food += 1;
            ChangeSprite();
            transform.RotateAround(transform.position, transform.forward, 180f);
            Debug.Log("a ant have delivered food");
        }
    }
} 