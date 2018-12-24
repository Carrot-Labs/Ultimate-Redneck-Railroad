using UnityEngine;
using System.Collections;

public class playerGun : MonoBehaviour {

    public GameObject projectile;
    public Vector3 gunForce;
    public int mouseButtonNumber = 0;
    public int coolDownTime = 0;
    public float flashIntensity = 0;
    public int flashTime = 0;
    public Rigidbody kickBackObject;
    public float kickBackScaler = 0;

    private Light gunFlash;
    private int flashCount = 0;
    private int coolDownCount = 0;
    
    // Use this for initialization
    void Start () {
        gunFlash = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButtonDown(mouseButtonNumber) && coolDownCount <= 0) {
            //set flash
            flashCount = flashTime;
            
            //handle the blasts differently depending on the type of bullet
            if(projectile.GetComponent<bullet>().bulletTupe == bullet.BulletType.RIFLE) {
                //rifle bullet
                generateBullet(transform, gunForce);
            } else {
                //shotgun bullet
                for(int i = 0; i < 5; i++) {
                    Vector3 appliedForce = Quaternion.AngleAxis(20*i -50 + Random.Range(-5,5), Vector3.forward) * gunForce;
                    generateBullet(transform, appliedForce);
                }
            }

            //set kickback from shot
            kickBackObject.AddForce(kickBackScaler * transform.TransformDirection(gunForce), ForceMode.Impulse);

            //set cooldown on shot so not rapid fire!
            coolDownCount = coolDownTime;
        }

        //flash the light to make the shot more cool
        if(flashCount > 0) {
            gunFlash.intensity = flashIntensity;
            flashCount--;
        }else{
            gunFlash.intensity = 0;
        }

        //work cooldown counter
        if(coolDownCount > 0) {
            coolDownCount--;
        }
	}

    private void generateBullet(Transform startPoint, Vector3 localDirection) {
        GameObject clone = (GameObject)(Instantiate(projectile, startPoint.position, startPoint.rotation));
        Vector3 appliedForce = transform.TransformDirection(localDirection);
        clone.GetComponent<bullet>().blast(appliedForce);
    }
}
