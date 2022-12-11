using UnityEngine;

public class AndroidSwipesController : MonoBehaviour
{
    [SerializeField] Vector3 movingDirection;
    [SerializeField] float _thrust =70f;
    // public const float MAX_SWIPE_TIME = 0.5f;

    // public const float MIN_SWIPE_DISTANCE = 0.17f;

    public static bool swipedRight = false;
    public static bool swipedLeft = false;
    public static bool swipedUp = false;
    public static bool swipedDown = false;


    public bool debugWithArrowKeys = true;

    private Vector2 physicalStartPos;
    private Vector2 physicalEndPos;
    private Vector2 startPos;
    float startTime;
    private void Update()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                startPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.height);
                // physicalStartPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);//to calculate physical length, width in both cases intentional
                startTime = Time.time;
            }
            if (t.phase == TouchPhase.Moved)
            {
                // if (Time.time - startTime > MAX_SWIPE_TIME) // press too long
                //     return;

                Vector2 endPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.height);
                Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);
                // physicalEndPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.width);
                // Vector2 physicalSwipe = new Vector2(physicalEndPos.x - physicalStartPos.x, physicalEndPos.y - physicalStartPos.y);

                // if (swipe.magnitude < MIN_SWIPE_DISTANCE) // Too short swipe
                //     return;
                // if (Mathf.Abs(physicalSwipe.x) > Mathf.Abs(physicalSwipe.y))
                // {
                    if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
                    { // Horizontal swipe
                        if (swipe.x > 0)
                        {
                            swipedLeft = true;
                            swipedRight = false;
                            swipedUp = false;
                            swipedDown = false;
                        }
                        else
                        {
                            swipedRight = true;
                            swipedLeft = false;
                            swipedUp = false;
                            swipedDown = false;
                        }
                    }
                // }
                // else if (Mathf.Abs(physicalSwipe.x) < Mathf.Abs(physicalSwipe.y))
                // { // Vertical swipe
                    if (Mathf.Abs(swipe.y) > Mathf.Abs(swipe.x))
                    {
                        if (swipe.y > 0)
                        {
                            swipedUp = true;
                            swipedRight = false;
                            swipedLeft = false;
                            swipedDown = false;
                        }
                        else
                        {
                            swipedDown = true;
                            swipedRight = false;
                            swipedLeft = false;
                            swipedUp = false;

                        }
                    }
                // }
            }
            if (t.phase == TouchPhase.Ended)
            {
                swipedDown = false;
                swipedRight = false;
                swipedLeft = false;
                swipedUp = false;
            }
            
        }

        if (debugWithArrowKeys)
        {
            swipedDown = swipedDown || Input.GetKeyDown(KeyCode.DownArrow);
            swipedUp = swipedUp || Input.GetKeyDown(KeyCode.UpArrow);
            swipedRight = swipedRight || Input.GetKeyDown(KeyCode.RightArrow);
            swipedLeft = swipedLeft || Input.GetKeyDown(KeyCode.LeftArrow);
        }
        // Rigidbody rb = this.GetComponent<Rigidbody>();
        // if (swipedUp == true)
        // {
        //     Debug.Log("Up");
        //     rb.AddForce(new Vector3(1, 0, 0) * _thrust);
        // }
        // if (swipedDown == true)
        // {
        //     rb.AddForce(new Vector3(-1, 0, 0) * _thrust);
        // }
        // if (swipedLeft == true)
        // {
        //     rb.AddForce(new Vector3(0, 0, -1) * _thrust);
        // }
        // if (swipedRight == true)
        // {
        //     rb.AddForce(new Vector3(0, 0, 1) * _thrust);
        // }

    }

    private void FixedUpdate()
    {      
        if (this.movingDirection.x>0)
        {
        if (swipedUp)
        {
            GetComponent<Rigidbody>().velocity += movingDirection;
        }
        else if (swipedDown)
        {
            GetComponent<Rigidbody>().velocity += -movingDirection;
        }
        }
        if (movingDirection.z>0)
        {
        if (swipedLeft)
        {
            GetComponent<Rigidbody>().velocity += -movingDirection;
        }
        else if (swipedRight)
        {
            GetComponent<Rigidbody>().velocity += movingDirection;
        }
        }
    }
    private void OnCollisionEnter(Collision other)
    {   
        if (other.gameObject.tag == "Block" || other.gameObject.tag == "Board")
        {
        swipedDown = false;
        swipedRight = false;
        swipedLeft = false;
        swipedUp = false;
        Rigidbody rb = this.GetComponent<Rigidbody>();
        Debug.Log(rb.velocity);
        rb.AddForce(new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z) * -1 * _thrust);
        }

    }
}

