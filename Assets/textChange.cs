using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textChange : MonoBehaviour {

    public Color clickedColor;
    public int transitionTime = 1;

    private Color originalColor;
    private Text text;
    private int counter = 0;

    void Start () {
        text = GetComponentInChildren<Text>();
	}

    public void OnClick()
    {
        if (counter == 0) { 
            counter = transitionTime;
        }
    }

    void Update()
    {
        if (counter == transitionTime)
        {
            //change color, wait, and then switch back
            originalColor = text.color;
            text.color = clickedColor;
            counter--;
        }else if(counter > 0)
        {
            counter--;
            if(counter == 0)
            {
                text.color = originalColor;
            }
        }
    }
}
