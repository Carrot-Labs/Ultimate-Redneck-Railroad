using UnityEngine;
using System.Collections;

public class enemyAttack : MonoBehaviour {

    public int attackStrength = 0;
    public int attackDelay = 0;

    private GameObject player;
    private int count  = 0;
	
	// Update is called once per frame
	void Update () {
        //attack if player is seen
	    if(player != null && count > attackDelay)
        {
            count = 0;
            player.GetComponent<playerHealth>().health -= attackStrength;
        }
        
        //delay loop for attacking
        if(count <= attackDelay)
        {
            count++;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = null;
        }
    }
}
