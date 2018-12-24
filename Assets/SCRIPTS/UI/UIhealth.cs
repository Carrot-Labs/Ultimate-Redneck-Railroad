using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIhealth : MonoBehaviour {

    private Slider healthBar;
    private playerHealth player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerHealth>();
        healthBar = GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
        healthBar.value = player.health;
	}
}
