using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntBehaviour : MonoBehaviour{
    private Rigidbody2D rigidbodyComponent;
    private FoodGrouping FG;
    private NestStorage NS;
    public SpriteRenderer spriteRenderer;
    public Sprite noFoodSprite;
    public Sprite foodSprite;
    public LayerMask targetMask;
    public LayerMask obstacleMask;
    public Transform redPheromone;
    public Transform bluePheromone;

    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    private float angleSegment;

    public float moveSpeed = 6;
    public bool holdingFood;
    private float weightLeft; 
    private float weightRight;
    private float weightForward;
    public float timeBeforeNewPheromone = 2.0f;
    public float timer = 0.0f;

    // Start is called before the first frame update
    void Start(){
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        NS = GetComponentInParent<NestStorage>();
        Physics2D.IgnoreLayerCollision(0,0,true);
        holdingFood = false;
        angleSegment = viewAngle / 3;
        StartCoroutine("FindTargetsWithDelay", .2f);
    }

    IEnumerator FindTargetsWithDelay(float delay){
        while (true) {
            yield return new WaitForSeconds(delay);
            FOVAssignWeights();
        }
    }

    // Update is called once per frame
    void FixedUpdate(){
        //FOVAssignWeights();

        move();

        pheromoneLayer();
    }

    void move(){
        int angle = pickDirection() + Random.Range(-1,2);
        
        rigidbodyComponent.velocity = transform.up * moveSpeed;
        transform.RotateAround(transform.position, transform.forward, angle);        
    }

    void pheromoneLayer(){
        timer += Time.deltaTime;
        if (holdingFood == true) {  //Holding food lay red pheromone
            if (timer > timeBeforeNewPheromone){
                Instantiate(redPheromone, transform.position, Quaternion.identity);
                timer = timer - timeBeforeNewPheromone;
            }
        }else{                      //Not holding food lay blue pheromone
            if (timer > timeBeforeNewPheromone){
                Instantiate(bluePheromone, transform.position, Quaternion.identity);
                timer = timer - timeBeforeNewPheromone;
            }
        }
    }

    void FOVAssignWeights(){
        //Reset weights
        weightLeft = 1;
        weightRight = 1;
        weightForward = 2;

        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++){
            Transform target = targetsInViewRadius[i].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(-transform.right, directionToTarget) < 90 - viewAngle/6 && Vector3.Angle(transform.up, directionToTarget) < viewAngle/2){
                weightLeft += AssignWeight(target);

            } else if (Vector3.Angle(transform.right, directionToTarget) < 90 - viewAngle/6 && Vector3.Angle(transform.up, directionToTarget) < viewAngle/2){
                weightRight += AssignWeight(target);

            } else if (Vector3.Angle(transform.up, directionToTarget) < viewAngle/6){
                weightForward += AssignWeight(target);
            }
        }
    }

    float AssignWeight(Transform target){
        float targetWeight = 0;
        if (target != null) {
            if (target.gameObject.layer == 9) {  //Red
                if (!holdingFood) targetWeight = 10;
                else targetWeight = 0.1f;
                
            } else if (target.gameObject.layer == 10) {  //Blue
                if (holdingFood) targetWeight = 10;
                else targetWeight = 0.1f;
                
            } else if (target.gameObject.layer == 8 && holdingFood) { //Nest
                targetWeight = 500;
            } else if (target.gameObject.layer == 6 && !holdingFood) {    //Food
                targetWeight = 500;
            }
        }
        return targetWeight;
    }

    int pickDirection(){
        float sum = weightLeft + weightForward + weightRight;
        float selected = Random.Range(0f, 1f) * sum;
        int chosenAngle = -1;

        if (selected <= weightLeft){
            chosenAngle = 5;   //turn left 5 degrees
        } else if (selected <= weightLeft + weightForward){
            chosenAngle = 0;   //go forward
        } else if (selected <= sum){
            chosenAngle = -5;  //turn right 5 degrees
        }
        return chosenAngle;
    }

    void ChangeSprite(){
        if (holdingFood){
            spriteRenderer.sprite = foodSprite;
        }
        else{
            spriteRenderer.sprite = noFoodSprite;
        }
    }

    void OnCollisionEnter2D(Collision2D collision2D){
        if (collision2D.gameObject.layer == 7){
            transform.RotateAround(transform.position, transform.forward, 90f);
        }
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.layer == 6 && !holdingFood){     //pick up food
            FG = col.gameObject.GetComponent<FoodGrouping>();
            FG.amountOfFood -= 1;
            FG.updateSize();
            holdingFood = true;
            ChangeSprite();
            transform.RotateAround(transform.position, transform.forward, 180f);
        } else if (col.gameObject.layer == 6 && holdingFood)
            transform.RotateAround(transform.position, transform.forward, 180f);

        if(col.gameObject.layer == 8 && holdingFood){       //deliver food to nest
            holdingFood = false;
            NS.food += 1;
            ChangeSprite();
            transform.RotateAround(transform.position, transform.forward, 180f);
        }
    }
}
