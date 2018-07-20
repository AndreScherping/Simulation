using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follower : MonoBehaviour {

    public Transform player;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    void Update ()
    {
		if(Vector3.Distance(transform.position, player.position) < 50)
        {
            agent.SetDestination(player.position);
        }
        //else if()
	}
}
