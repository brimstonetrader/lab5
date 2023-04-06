using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Finder : MonoBehaviour
{
    public Transform goal;
    public GameObject body;

    private Rigidbody rigidbody;

    private Animator animator;

    private NavMeshAgent agent;

    private bool grounded = true;
    
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position; 
        animator = body.GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", agent.velocity.sqrMagnitude);

        // https://stackoverflow.com/questions/66007738/unity-how-to-jump-using-a-navmeshagent-and-click-to-move-logic
        // clicking on the nav mesh, sets the destination of the agent and off he goes
        if (Input.GetMouseButtonDown(0) && (!agent.isStopped))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(new Vector3(0,-3,0));
            }
        }

        
    }

    /// <summary>
    /// Check for collision back to the ground, and re-enable the NavMeshAgent
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        print("Hit Something!");
        if (collision.collider != null && collision.collider.tag == "Ground")
        {
            print("It is the ground!");
            if (!grounded)
            {
                if (agent.enabled)
                {
                    agent.nextPosition = transform.position;
                    agent.SetDestination(transform.position);
                    agent.updatePosition = true;
                    agent.updateRotation = true;
                    agent.isStopped = false;
                }
                rigidbody.isKinematic = true;
                rigidbody.useGravity = false;
                grounded = true;
            }
        }
    }
}
