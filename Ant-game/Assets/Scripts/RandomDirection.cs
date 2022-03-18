using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform Pick(List<Transform> targets){
        List<float> weights = AssignWeights(targets);
        return WeightedChance(targets, weights);
    }

    List<float> AssignWeights(List<Transform> targets){
        List<float> weights = new List<float>();
        foreach (Transform target in targets){
            weights.Add(Random.Range(0f,10f));
        }
        return weights;
    }

    Transform WeightedChance(List<Transform> targets, List<float> weights){
        float sum = 0;

        foreach (float value in weights){
            sum += value;
        }

        float selected = Random.Range(0f, 10f) * sum;
        int lastGoodID = -1;
        int chosenID = 0;
        sum = 0;
        for (int weightIndex = 0; weightIndex < weights.Count; weightIndex++){
            sum += weights[weightIndex];
            if (weights[weightIndex] > 0){
                if (selected <= sum){
                    chosenID = weightIndex;
                    break;
                }
                lastGoodID = weightIndex;
            }

            if (weightIndex == weights.Count - 1){
                chosenID = lastGoodID;
            }
        }

        return targets[chosenID];
    }
}
