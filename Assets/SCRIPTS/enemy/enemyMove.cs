using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour {

    private UnityEngine.AI.NavMeshAgent agent;
    private Transform playerTF = null;

    public enemyAttack attackScript;
    public enemyHealth healthScript;

    public bool rotateState = false;

	// Use this for initialization
	void Start () {
        agent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        if(healthScript.health <= 0)
        {
            dead();
        }
        else if(playerTF != null)
        {
            trackPlayer();
        }else
        {
            wander();
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTF = other.transform;
        }        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTF = null;
        }
    }

    private void wander()
    {
        agent.Move(new Vector3(1*Time.deltaTime,0,0));
    }

    private void trackPlayer()
    {
        agent.destination = playerTF.position;
        agent.updateRotation = false;

        if(!rotateState && playerTF.position.x < transform.parent.position.x )
        {
            transform.parent.Rotate(new Vector3(0, 180, 0));
            rotateState = true;
        }
        else if(rotateState && playerTF.position.x > transform.parent.position.x)
        {
            transform.parent.Rotate(new Vector3(0, 180, 0));
            rotateState = false;
        }
    }

    private void dead()
    {
        attackScript.attackStrength = 0;
    }
}
