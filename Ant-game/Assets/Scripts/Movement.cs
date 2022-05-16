using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Movement: MonoBehaviour{
    private Rigidbody2D rigidbodyComponent;
    private Rigidbody2D rigidbodyComponentChild;
    private FieldOfView fow;
    public SpriteRenderer spriteRenderer;
    public Sprite noFoodSprite;
    public Sprite foodSprite;
    public float moveSpeed = 6;
    public bool holdingFood;

    List<float> weights;    //{left,    middle,     right}
    List<int> turnAngles;   //{turn left, no turning, turn right}
    
    // Start is called before the first frame update
    void Start(){
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        fow = GetComponent<FieldOfView>();
        weights = new List<float>{1,1,1};
        turnAngles = new List<int>{5,0,-5};
        holdingFood = false;
    }

    void ChangeSprite(){
        if (holdingFood){
            spriteRenderer.sprite = foodSprite;
        }
        else{
            spriteRenderer.sprite = noFoodSprite;
        }
    }

    // Update is called once per frame
    void Update(){

    }
    // Update is called once per phycis update
    void FixedUpdate(){        
        move();
    }

    void move(){
        AssignWeightsLeftMidRight();
        int angleIndex = WeightedChance(weights);
        int angle = turnAngles[angleIndex];
        
        rigidbodyComponent.velocity = transform.up * moveSpeed;
        transform.RotateAround(transform.position, transform.forward, angle);

        //Reset weights
        weights[0] = 1;     //Left
        weights[1] = 1;     //Middle
        weights[2] = 1;     //Right

        //Bias toward repeating 
        //weights[angleIndex] += 5;
    }

    float AssignWeight(List<Transform> targets){
        float collectiveWeight = 0;
        //float weight;
        foreach (Transform target in targets){
            if (target.gameObject.layer == 9) {  //Red
            
                if (!holdingFood){
                    collectiveWeight += 10;
                }

            } else if (target.gameObject.layer == 10){  //Blue
                
                if (holdingFood){
                    collectiveWeight += 10;
                }

            } else if (target.gameObject.layer == 8) { //nest
                
                if (holdingFood){
                    collectiveWeight += 50;
                }
                
            } else { //food
                if (!holdingFood){
                    collectiveWeight += 50;
                }
            }
            
        }
        return collectiveWeight;
    }

    void AssignWeightsLeftMidRight(){
        if (fow.visibleTargetsLeft.Count > 0){   //Left
            weights[0] += AssignWeight(fow.visibleTargetsLeft);
        }
        if (fow.visibleTargetsMid.Count > 0){   //Middle
            weights[1] += AssignWeight(fow.visibleTargetsMid);
        }
        if (fow.visibleTargetsRight.Count > 0){ //Right
            weights[2] += AssignWeight(fow.visibleTargetsRight);
        }
        //Debug.Log("weight of left: "+ weights[0] +", weight of middle: "+ weights[1] +", weight of Right: "+ weights[2]);
    }

    int WeightedChance(List<float> weights){
        float sum = 0;

        foreach (float value in weights){
            sum += value;
        }

        float selected = Random.Range(0f, 1f) * sum;
        //Debug.Log("selected: "+ selected);
        int lastGoodID = -1;
        int chosenID = 0;
        sum = 0;
        for (int weightIndex = 0; weightIndex < weights.Count; weightIndex++){
            sum += weights[weightIndex];
            //Debug.Log("sum: "+ sum);
            if (weights[weightIndex] > 0){
                if (sum >= selected){
                    //Debug.Log("YEEEEEEEEEEEEEEEEES");
                    chosenID = weightIndex;
                    break;
                }
                lastGoodID = weightIndex;
            }

            if (weightIndex == weights.Count - 1){
                chosenID = lastGoodID;
            }
        }

        return chosenID;
    }

    
    void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.layer == 7){
            transform.RotateAround(transform.position, transform.forward, 90f);
        }
<<<<<<< Updated upstream
    }

    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.layer == 6 && !holdingFood){
            Destroy(col.gameObject);
=======
        if (col.gameObject.layer == 6 && !holdingFood){     //pick up food
            FG = col.gameObject.GetComponent<FoodGrouping>();
            FG.amountOfFood -= 1;
            FG.updateSize();
>>>>>>> Stashed changes
            holdingFood = true;
            Debug.Log("a ant is holding food");
            ChangeSprite();
            transform.RotateAround(transform.position, transform.forward, 180f);
        }
        if(col.gameObject.layer == 8 && holdingFood){
            holdingFood = false;
            ChangeSprite();
            transform.RotateAround(transform.position, transform.forward, 180f);
            Debug.Log("a ant have delivered food");
        }
    }
<<<<<<< Updated upstream
    

=======

    //private void OnTriggerEnter2D(Collider2D col){

    //}
>>>>>>> Stashed changes
}
