using UnityEngine;
using System.Collections;



public class trackPlayer : MonoBehaviour {

    public GameObject player;

    public float min_x;
    public float min_y;
    public float max_x;
    public float max_y;

    public float x_offset;
    public float y_offset;

    public float trackSpeed;
	
	// Update is called once per frame
	void Update () {

        //calculate next vector
        Vector3 playerVect = player.transform.position;
        Vector3 diffVect = new Vector3(playerVect.x - transform.position.x + x_offset, playerVect.y - transform.position.y + y_offset, 0);
        Vector3 nextVect = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        //check deadzone
        if (diffVect.x < min_x || diffVect.x > max_x) {
            nextVect.x += diffVect.x;
        }
        if (diffVect.y < min_y || diffVect.y > max_y) {
            nextVect.y += diffVect.y;
        }

        //apply lerp to smooth into next vector
        transform.position = Vector3.Lerp(transform.position, nextVect, Time.deltaTime * trackSpeed);

        //set player's caneraCenterX point in pixels
        player.GetComponent<playerMovement>().camCenterX = GetComponent<Camera>().WorldToScreenPoint(player.transform.position).x;
    }
}
