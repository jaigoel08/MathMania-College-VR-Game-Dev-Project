using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class aiMovement : MonoBehaviour
{
    GameObject target;
    NavMeshAgent nm;
    Rigidbody rb;
    Animator anim;
    public Transform Target;
    public Transform[] Waypoints;
    public int Cur_Waypoint;
    public float speed, stop_distance;
    public float PauseTimer;
    [SerializeField]
    private float cur_timer;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        nm = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        rb.freezeRotation = true;
        Target = Waypoints[Cur_Waypoint];
        cur_timer = PauseTimer;

    }

    // Update is called once per frame
    void Update()
    {

        
        nm.acceleration = speed;
        nm.stoppingDistance = stop_distance;
        float distance = Vector3.Distance(transform.position, Target.position);

        if (distance > stop_distance && Waypoints.Length > 0)
        {
            anim.SetBool("isWalking", true);
            Target = Waypoints[Cur_Waypoint];
        }

        else if(distance <= stop_distance && Waypoints.Length > 0)
        {
            Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
            transform.LookAt(targetPosition);
            anim.SetBool("isWalking", false);
            if (cur_timer > 0)
            {
                cur_timer -= 0.01f;

            }
            if(cur_timer <= 0)
            {
                Cur_Waypoint++;
                if (Cur_Waypoint >= Waypoints.Length)
                {
                    Cur_Waypoint = 0;
                }
                Target = Waypoints[Cur_Waypoint];
                cur_timer = PauseTimer;

            }


        }
        
        nm.SetDestination(Target.position);
    }
}
