using UnityEngine;
using System.Collections;

public class clothWind : MonoBehaviour {

    public Transform referencePosistion;
    public Transform windPosition;
    public float windStrength = 0;

    // Update is called once per frame
    void Update()
    {
        //use the angle difference to determine which direction the object is facing for cloth wind
        float angleDif = referencePosistion.rotation.y - windPosition.rotation.y;
        float windDirection = (angleDif < 20f && angleDif > -20f) ? -1 : 1;

        //apply wind
        GetComponent<Cloth>().externalAcceleration = new Vector3(windDirection * windStrength, 0, 0);
    }
}
