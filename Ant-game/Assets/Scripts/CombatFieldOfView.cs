using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CombatFieldOfView : MonoBehaviour{

    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    float angleSegment;

    public LayerMask targetMask;
    public LayerMask obstacleMask; //not used yet

    //[HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    void Start(){
        StartCoroutine("FindTargetsWithDelay", .2f);
        angleSegment = viewAngle / 3;
    }

    IEnumerator FindTargetsWithDelay(float delay){
        while (true) {
            yield return new WaitForSeconds(delay);
            FindVisableTargets();
        }
    }

    void FindVisableTargets(){
        visibleTargets.Clear();
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++){
            Transform target = targetsInViewRadius[i].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.up, directionToTarget) < viewAngle){
                visibleTargets.Add(target);
            
            }
        }
    }
}

// Source from https://www.youtube.com/watch?v=rQG9aUWarwE&ab_channel=SebastianLague with additions to serve our purpose.
