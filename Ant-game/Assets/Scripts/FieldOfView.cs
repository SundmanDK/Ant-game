using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FieldOfView : MonoBehaviour{

    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;
    float angleSegment;

    public LayerMask targetMask;
    public LayerMask obstacleMask; //not used yet

    //[HideInInspector]
    public List<Transform> visibleTargetsMid = new List<Transform>();
    public List<Transform> visibleTargetsLeft = new List<Transform>();
    public List<Transform> visibleTargetsRight = new List<Transform>();

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
        visibleTargetsMid.Clear();
        visibleTargetsLeft.Clear();
        visibleTargetsRight.Clear();
        Collider2D[] targetsInViewRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++){
            Transform target = targetsInViewRadius[i].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(-transform.right, directionToTarget) < 90 - viewAngle/6 && Vector3.Angle(transform.up, directionToTarget) < viewAngle/2){
                visibleTargetsLeft.Add(target);

            } else if (Vector3.Angle(transform.right, directionToTarget) < 90 - viewAngle/6 && Vector3.Angle(transform.up, directionToTarget) < viewAngle/2){
                visibleTargetsRight.Add(target);

            } else if (Vector3.Angle(transform.up, directionToTarget) < viewAngle/6){
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask)){
                    visibleTargetsMid.Add(target);
                }
            }
        }
    }


    public Vector3 DirectionFromAngle(float angleInDegrees, bool angleIsGlobal){
        if (!angleIsGlobal){
            angleInDegrees += transform.eulerAngles.z;
        }

        return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0);

    }
}

// Source from https://www.youtube.com/watch?v=rQG9aUWarwE&ab_channel=SebastianLague with additions to serve our purpose.
