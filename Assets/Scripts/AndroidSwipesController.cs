using UnityEngine;
using System;

public class AndroidSwipesController : MonoBehaviour
{
    [SerializeField] Vector3 movingDirection;

    public Vector3 velocity;

    // public const float MAX_SWIPE_TIME = 0.5f;

    // public const float MIN_SWIPE_DISTANCE = 0.17f;

    public static bool swipedRight = false;
    public static bool swipedLeft = false;
    public static bool swipedUp = false;
    public static bool swipedDown = false;


    public bool debugWithArrowKeys = true;
    private Vector2 startPos;
    private void Update()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                startPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.height);
                          }
            if (t.phase == TouchPhase.Moved)
            {
                              Vector2 endPos = new Vector2(t.position.x / (float)Screen.width, t.position.y / (float)Screen.height);
                Vector2 swipe = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);
                
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
                // Vertical swipe
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
    }

    private void FixedUpdate()
    {
        if (this.movingDirection.x > 0)
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
        if (movingDirection.z > 0)
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
        this.velocity = GetComponent<Rigidbody>().velocity; // to be used during collides calculation (CollidesController)
    }
}

