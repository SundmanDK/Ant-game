using UnityEngine;
using System.Collections;

public class ControlableAnt : MonoBehaviour{
    private Rigidbody2D rigidbodyComponent;
    private Rigidbody2D rigidbodyComponentChild;
    private GameObject Marker;
    private CombatFieldOfView fow;
    private FoodGrouping FG;
    private NestStorage NS;
    public SpriteRenderer spriteRenderer;
    public Sprite noFoodSprite;
    public Sprite foodSprite;
    public GameObject food;
    

    public float moveSpeed;
    public bool holdingFood;
    private bool goTo = false;
    private float angle;
    Camera viewCamera;

    public int maxHealth = 25;
    public int currentHealth;
    private Stats stats;

    public HealthBar healthBar;

    

    void Start(){
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        NS = GetComponentInParent<NestStorage>();
        fow = GetComponent<CombatFieldOfView>();
        Marker = GameObject.Find("GoToMarker");
        viewCamera = Camera.main;
        Physics2D.IgnoreLayerCollision(0,0,true);
        holdingFood = false;
        stats = GetComponent<Stats>(); 
        moveSpeed = stats.moveSpeed;

    }

    void Update(){ 
        Vector3 mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0) && mousePos.y > 230)
            goTo = true;
    }

    void TakeDamage(int damage){
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        updateHealthbar();
    }

    public void updateHealthbar(){
        healthBar.SetHealth(currentHealth);
    }


    void FixedUpdate(){
        if (goTo)
            MoveTo(Marker.transform);
        else if (fow.visibleTargets.Count > 0)
            MoveTo(fow.visibleTargets[0]);
    }

    void MoveTo(Transform destination){
        Vector3 directionToTarget = (destination.position - transform.position).normalized;
        float angle = Vector3.Angle(transform.up, directionToTarget);
        transform.RotateAround(transform.position, transform.forward, angle);
        rigidbodyComponent.velocity = transform.up * stats.moveSpeed;
    }

    void ChangeSprite(){
        if (holdingFood){
            spriteRenderer.sprite = foodSprite;
        }
        else{
            spriteRenderer.sprite = noFoodSprite;
        }
    }

    private void OnTriggerExit2D(){
        if (fow.visibleTargets.Count == 0)
            goTo = true;
    }

    private void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.layer == 7){
            goTo = false;
            rigidbodyComponent.velocity = new Vector3(0,0,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.layer == 6 && !holdingFood){     //pick up food
            FG = col.gameObject.GetComponent<FoodGrouping>();
            FG.amountOfFood -= 2;
            FG.updateSize();
            holdingFood = true;
            ChangeSprite();
        }
        if (col.gameObject.layer == 8 && holdingFood){       //deliver food to nest
            holdingFood = false;
            NS.food += 2;
            ChangeSprite();
        }
        if (col.gameObject.layer == 11){
            goTo = false;
            rigidbodyComponent.velocity = new Vector3(0,0,0);
        }
    }
} 