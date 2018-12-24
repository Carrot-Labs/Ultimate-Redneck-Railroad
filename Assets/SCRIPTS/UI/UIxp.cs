using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIxp : MonoBehaviour {

    private gameXP stat;
    private Text xpText;

	// Use this for initialization
	void Start () {
        stat = GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameXP>();
        xpText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        xpText.text = "Score: " + stat.xp;
	}
}
