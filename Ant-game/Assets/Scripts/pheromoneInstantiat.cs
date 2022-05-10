using UnityEngine;
using System.Collections;

public class pheromoneInstantiat : MonoBehaviour
{
    public float timeToThink = 2.0f;
    public float timer = 0.0f;
    public float weight = 1;
    private AntBehaviour mT;
    public Transform redPheromone;
    public Transform bluePheromone;
    
    void Start()
    {
        mT = GetComponent<AntBehaviour>();
    }



    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (mT.holdingFood == true) { //Debug.Log("I'm holding food, so I'm releasing red pheromones");
            if (timer > timeToThink){
                Instantiate(redPheromone, transform.position, Quaternion.identity);
                timer = timer - timeToThink;
            }


        }else{ //Debug.Log("I'm not holding food, so I'm releasing blue pheromones");
            if (timer > timeToThink){
                Instantiate(bluePheromone, transform.position, Quaternion.identity);
                timer = timer - timeToThink;
            }
        }
       
    }
}