using UnityEngine;
using System.Collections;

public class armAnimation : MonoBehaviour {

    public float speed = 0;

    public float upperRotationBound = 0;
    public float lowerRotationBound = 0;


    private Rigidbody[] arms;

	// Use this for initialization
	void Start () {
        //get the arms of this object (should ideally be 2 :))
        arms = GetComponentsInChildren<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {
        //get mouse position into world space
        Vector3 obj = arms[0].transform.position;
        obj.z = 0;
        Vector3 pos = Camera.main.WorldToScreenPoint(obj);
        Vector3 dir = Input.mousePosition - pos;
        if (dir.x < 0) dir.x *= -1;
        float angle = -Mathf.Atan(dir.y / dir.x) * Mathf.Rad2Deg;
        float error = angle - arms[0].transform.rotation.eulerAngles.z;

        //set rotation
        if (angle < upperRotationBound && angle > lowerRotationBound)
        {
            //iterate through arms
            foreach(Rigidbody rb in arms)
            {
                rb.transform.Rotate(new Vector3(0, 0, speed * error), Space.Self);
            }
        }
    }
}
