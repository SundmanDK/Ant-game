using UnityEngine;
using System.Collections;

public class ControlableAnt : MonoBehaviour{
    private Rigidbody2D rigidbodyComponent;
    private Rigidbody2D rigidbodyComponentChild;
    private GameObject Marker;
    private FieldOfView fow;
    private NestStorage NS;
    public SpriteRenderer spriteRenderer;
    public Sprite noFoodSprite;
    public Sprite foodSprite;
    public GameObject food;

    public float moveSpeed = 8;
    public bool holdingFood;
    private bool goTo = false;
    private float angle;
    Camera viewCamera;

    void Start(){
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        NS = GetComponentInParent<NestStorage>();
        fow = GetComponent<FieldOfView>();
        Marker = GameObject.Find("GoToMarker");
        viewCamera = Camera.main;
        Physics2D.IgnoreLayerCollision(0,0,true);
        holdingFood = false;
    }

    void Update(){
        if (Input.GetMouseButtonDown(0))
            goTo = true;
    }

    void FixedUpdate(){
        if (goTo)
            move();
    }

    void move(){
        Vector3 directionToTarget = (Marker.transform.position - transform.position).normalized;
        float angle = Vector3.Angle(transform.up, directionToTarget);
        transform.RotateAround(transform.position, transform.forward, angle);
        rigidbodyComponent.velocity = transform.up * moveSpeed;
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
            ChangeSprite();
        }
        if(col.gameObject.layer == 8 && holdingFood){
            holdingFood = false;
            NS.food += 1;
            ChangeSprite();
        }
        if (col.gameObject.layer == 11 || col.gameObject.layer == 7){
            goTo = false;
            rigidbodyComponent.velocity = new Vector3(0,0,0);
        }
    }
} 