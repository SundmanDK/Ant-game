using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirection : MonoBehaviour{
    List<int> turnAngle;


    // Start is called before the first frame update
    void Start(){
        turnAngle  = new List<int>();
        turnAngle.Add(0);
        turnAngle.Add(10);
        turnAngle.Add(-10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Pick(List<Transform> TMid, List<Transform> TLeft, List<Transform> TRight){
        List<float> weights = new List<float>();
        weights.Add(AssignWeight(TMid));
        weights.Add(AssignWeight(TLeft));
        weights.Add(AssignWeight(TRight));

        return WeightedChance(turnAngle, weights);
    }

    float AssignWeight(List<Transform> targets){
        float collectiveWeight = 0;
        foreach (Transform target in targets){
            collectiveWeight += Random.Range(0f,10f);
        }
        return collectiveWeight;
    }

    int WeightedChance(List<int> result, List<float> weights){
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

        return result[chosenID];
    }
}
