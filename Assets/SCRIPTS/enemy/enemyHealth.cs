using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {

    public int health = 0;
    public int delay = 0;
    public int xp = 0;

    private GameObject gameManager = null;

    //todo add xp calculation mechanism here
	void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gameManager");
    }

	// Update is called once per frame
	void Update () {
        if(health <= 0)
        {
            gameManager.GetComponent<gameXP>().xp += xp;
            Destroy(this.gameObject.transform.parent.gameObject, delay);
        }
	}
}

