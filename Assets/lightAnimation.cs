using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightAnimation : MonoBehaviour {

    public float offset = 0;
    public float waveScaler = 1;
    public float randMax = 1;
    public float randMin = -1;
    public int delayCount = 10;

    private Light[] lights;
    private int updateCounter = 0;

	// Use this for initialization
	void Start () {
        lights = GetComponentsInChildren<Light>();
	}

    // Update is called once per frame
    void Update() {
        if (updateCounter == 0) { 
            foreach (Light l in lights)
            {
                l.intensity = offset + waveScaler * Mathf.Abs(Mathf.Sin(Time.time)) + Random.Range(randMin, randMax);
            }
            updateCounter = delayCount;
        }
        else
        {
            updateCounter--;
        }
	}
}
