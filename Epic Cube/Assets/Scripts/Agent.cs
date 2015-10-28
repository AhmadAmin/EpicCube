using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour {
        
	protected NavMeshAgent		agent;
	protected Animator			animator;

	protected Locomotion locomotion;
    GameObject player;


	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;

		animator = GetComponent<Animator>();
		locomotion = new Locomotion(animator);
        player = GameObject.FindGameObjectWithTag("Player");

	}

	protected void SetDestination()
	{
        // Construct a ray from the current mouse coordinates

        agent.destination = player.transform.position;
	}

	protected void SetupAgentLocomotion()
	{
		if (AgentDone())
		{
			locomotion.Do(0, 0);			
		}
		else
		{
			float speed = agent.desiredVelocity.magnitude;

			Vector3 velocity = Quaternion.Inverse(transform.rotation) * agent.desiredVelocity;

			float angle = Mathf.Atan2(velocity.x, velocity.z) * 180.0f / 3.14159f;

			locomotion.Do(speed, angle);
		}
	}

    void OnAnimatorMove()
    {
        agent.velocity = animator.deltaPosition / Time.deltaTime;
		transform.rotation = animator.rootRotation;
    }

	protected bool AgentDone()
	{
		return !agent.pathPending && AgentStopping();
	}

	protected bool AgentStopping()
	{
		return agent.remainingDistance <= agent.stoppingDistance;
	}

	// Update is called once per frame
	void Update () 
	{ 
		SetDestination();
        SetupAgentLocomotion();
	}
}
