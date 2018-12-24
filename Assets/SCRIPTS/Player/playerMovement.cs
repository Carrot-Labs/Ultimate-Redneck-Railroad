using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    private enum direction
    {
        FORWARD,
        BACKWARD
    }

    //max threshold for holding jump
    public int jumpHoldThreshold = 2;
    //translation speed
    public float runSpeed = 0;
    //max power for the jump
    public float jumpPower = 0;
    //roation speed
    public float rotationSpeed = 0;
    //public float camera center for rotation point
    public float camCenterX = 0;
    //public falling ignore for jump
    public int fallingHoldThreshold = 2;

    //current holding amount
    private int jumpHold = 0;
    private int fallingHold = 0;
    //rotation state information
    private float degreesLeftRotation = 0;
    private direction heading = direction.FORWARD;
    private bool falling = false;

    // Update is called once per frame
    void Update() {
        // movement accross the train
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * runSpeed * Time.deltaTime, 0, 0);
        bool running = horizontal != 0;
        
        //track mouse
        float mouseX = Input.mousePosition.x - camCenterX;
        rotate(mouseX);

        //vertical movement
        bool jumping = jump();

        //set the animator
        animatePlayer(running, jumping, falling);

        //falling hold counter
        if(falling && fallingHold < fallingHoldThreshold)
        {
            fallingHold++;
        }
    }

    //colliding with something, if floor then reset jump
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("floor")) {
            jumpHold = 0;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            falling = false;
            fallingHold = 0;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("floor"))
        {
            falling = true;    
        }
    }

    //performs the necessary jump action
    private bool jump() {
        bool retVal = false;
        // movement in the air duh
        float jump = Input.GetAxis("Jump");

        if (jump > 0 && jumpHold < jumpHoldThreshold && fallingHold < fallingHoldThreshold)
        {
            GetComponent<Rigidbody>().AddForce(0, jumpPower, 0);
            jumpHold++;
            retVal = true;
        }
        else if (jumpHold > 0 && jumpHold < jumpHoldThreshold)
        {
            jumpHold++;
        }
        return retVal;
    }

    private void rotate(float horizontal) {
        if (horizontal < 0 && heading == direction.BACKWARD) {
            degreesLeftRotation = 180 + degreesLeftRotation;
            heading = direction.FORWARD;
        }
        else if (horizontal > 0 && heading == direction.FORWARD) {
            degreesLeftRotation = 180 + degreesLeftRotation;
            heading = direction.BACKWARD;
        }

        //rotate to face forward
        if (degreesLeftRotation > 0) {
            float degreesMoved = degreesLeftRotation * rotationSpeed;
            if (degreesMoved > degreesLeftRotation) {
                degreesMoved = degreesLeftRotation;
            }
            degreesLeftRotation -= degreesMoved;

            transform.GetChild(0).GetComponent<Transform>().Rotate(0, degreesMoved, 0);
        }
    }

    private void animatePlayer(bool running, bool jumping, bool falling) {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("running", running);
        anim.SetBool("jumping", jumping);
        anim.SetBool("falling", falling);
    }
}
