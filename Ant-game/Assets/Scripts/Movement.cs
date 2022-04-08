using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour{
    private Rigidbody2D rigidbodyComponent;
    private Rigidbody2D rigidbodyComponentChild;
    private FieldOfView fow;
    GameObject Nest;
    private NestStorage NS;
    public SpriteRenderer spriteRenderer;
    public Sprite noFoodSprite;
    public Sprite foodSprite;
    public GameObject food;

    public float moveSpeed = 6;
    public bool holdingFood;

    List<float> weights;    //{left,    middle,     right}
    List<int> turnAngles;   //{turn left, no turning, turn right}
    

    // Start is called before the first frame update
    void Start(){
        rigidbodyComponent = GetComponent<Rigidbody2D>();
        NS = Nest.GetComponent<NestStorage>();
        fow = GetComponent<FieldOfView>();
        Physics2D.IgnoreLayerCollision(0,0,true);
        weights = new List<float>{1,2,1};
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

    // Update is called once per phycis update
    void FixedUpdate(){
        move();
    }

    void move(){
        AssignWeightsLeftMidRight();
        //int angleIndex = WeightedChance();//weights);
        int angle = turnAngles[WeightedChance()];
        
        rigidbodyComponent.velocity = transform.up * moveSpeed;
        transform.RotateAround(transform.position, transform.forward, angle);

        //Reset weights
        weights[0] = 1;     //Left
        weights[1] = 2;     //Middle
        weights[2] = 1;     //Right
    }

    float AssignWeight(List<Transform> targets){
        float collectiveWeight = 0;
        foreach (Transform target in targets){
            if (target.gameObject.layer == 9) {  //Red
                if (!holdingFood){
                    collectiveWeight += 10;
                } else {
                    collectiveWeight += 0.1f;
                }
            } else if (target.gameObject.layer == 10){  //Blue
                if (holdingFood){
                    collectiveWeight += 10;
                } else {
                    collectiveWeight += 0.1f;
                }
            } else if (target.gameObject.layer == 8) { //Nest
                if (holdingFood){
                    collectiveWeight += 500;
                }
            } else {    //Food
                if (!holdingFood){
                    collectiveWeight += 500;
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

    int WeightedChance(){
        float sum = weights[0] + weights[1] + weights[2];
        float selected = Random.Range(0f, 1f) * sum;
        int chosenID = -1;

        if (selected <= weights[0]){
            chosenID = 0;
        } else if (selected <= weights[0] + weights[1]){
            chosenID = 1;
        } else if (selected <= weights[0] + weights[1] + weights[2]){
            chosenID = 2;
        }
        return chosenID;
    }
    
    void OnCollisionEnter2D(Collision2D collision2D){
        if (collision2D.gameObject.layer == 7){
            transform.RotateAround(transform.position, transform.forward, 90f);
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
            //NS.food += 1;
            ChangeSprite();
            transform.RotateAround(transform.position, transform.forward, 180f);
            Debug.Log("a ant have delivered food");
        }
    }
    

    /*
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
        /*
        Sourced from https://github.com/chancejs/chancejs/blob/master/docs/chance.js lines 518 - 573. 
        Which is part of a javascript library which we rewrote in C#
        
    }
*/

}
