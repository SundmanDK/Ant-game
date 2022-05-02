using UnityEngine;
using System.Collections;

public class pheromoneControlableAnt : MonoBehaviour
{
    public float timeToThink = 2.0f;
    public float timer = 0.0f;
    public float weight = 1;
    private ControlableAnt move;
    public Transform redPheromone;
    public Transform bluePheromone;
    void Start()
    {
        move = GetComponent<ControlableAnt>();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (move.holdingFood == true) { //Debug.Log("I'm holding food, so I'm releasing red pheromones");
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