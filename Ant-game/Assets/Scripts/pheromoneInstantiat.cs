using UnityEngine;
using System.Collections;

public class pheromoneInstantiat : MonoBehaviour
{
    public float timeToThink = 2.0f;
    public float timer = 0.0f;
    public float weight = 1;
    private Movement mT;
    public Transform prefab1;
    public Transform prefab2;
    void Start()
    {
        mT = GetComponent<Movement>();
    }



    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (mT.holdingFood == true) { //Debug.Log("I'm holding food, so I'm releasing red pheromones");
            if (timer > timeToThink){
                Instantiate(prefab1, transform.position, Quaternion.identity);
                timer = timer - timeToThink;
            }


        }else{ //Debug.Log("I'm not holding food, so I'm releasing blue pheromones");
            if (timer > timeToThink){
                Instantiate(prefab2, transform.position, Quaternion.identity);
                timer = timer - timeToThink;
            }
        }
       
    }
}