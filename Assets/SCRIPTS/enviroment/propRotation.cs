using UnityEngine;
using System.Collections;

public class propRotation : MonoBehaviour {

    public float speed = 0;

	// Update is called once per frame
	void Update () {
        transform.Rotate(speed,0, 0);
	}
}
