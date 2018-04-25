using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float forwardForce = 3000F;
    public float sidewaysForce = 90F;

    // Android test code
    private Vector2 touchOrigin = -Vector2.one;

	// Use this for initialization
    // Executed when the game starts
	//void Start () {
 //       //Debug.Log("Hello, world!");
 //       //rb.AddForce(0, 200, 500);
	//}
	
	// Update is called once per frame
    // FixedUpdate for physics calculations
	void FixedUpdate () {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if (rb.position.y < -1F)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        #if (UNITY_STANDALONE)
            Debug.Log("standalone");
            if (Input.GetKey("d"))
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (Input.GetKey("a"))
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        #else
            Debug.Log(Screen.width);
            if (Input.touchCount > 0)
            {
                Touch myTouch = Input.touches[0];
                touchOrigin = myTouch.position;
                if (touchOrigin.x <= (Screen.width / 2))
                {
                    rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
                else if (touchOrigin.x > (Screen.width / 2))
                {
                    rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                }
            //if (myTouch.phase == TouchPhase.Began)
            //{
            //    touchOrigin = myTouch.position;
            //    if (touchOrigin.x <= (Screen.width / 2))
            //    {
            //        rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            //    }
            //    else if (touchOrigin.x > (Screen.width / 2))
            //    {
            //        rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            //    }
            //}
            //else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
            //{
            //    Vector2 touchEnd = myTouch.position;
            //    float x = touchEnd.x - touchOrigin.x;
            //    if (x <= (Screen.width / 2))
            //    {
            //        rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            //    }
            //    else if (x > (Screen.width / 2))
            //    {
            //        rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            //    }
            //}
        }
        #endif
        // deleteTime is the amount of seconds since the computer drew the last frame 10 times a second then this value is .1
        // Add a forward force

        // Best practice is to have variables in update method like bool moveright and thenhave methods in Fixed update to add the movement




    }
}