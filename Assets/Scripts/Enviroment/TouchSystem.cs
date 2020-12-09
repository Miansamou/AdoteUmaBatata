using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSystem : MonoBehaviour
{

    public static TouchSystem instance;

    private Touch touch;
    private Vector2 firstPos;
    private Vector2 variantPos;
    private Vector2 lastPos;
    private Vector2 currentSwipe;
    private float deltaVertical;
    private float rightScreen;
    private float leftScreen;
    private bool enable;

    private bool dialogueOpened = false;

    private void Awake()
    {
        // Don't create two objects for the touch system
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        screenSizeResolution();
    }

    // Define the origin and end of when the player touch the screen
    private void SwipeControl()
    {
        if (Input.touches.Length == 1)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                firstPos = new Vector2(touch.position.x, touch.position.y);
            }

            if (touch.phase == TouchPhase.Moved)
            {
                variantPos = new Vector2(touch.position.x, touch.position.y);

                deltaVertical =  touch.deltaPosition.y;

                CurrentSwipe(variantPos);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                lastPos = new Vector2(touch.position.x, touch.position.y);

                CurrentSwipe(lastPos);
            }
        }
    }

    // Define true if the player make the up swipe movement and false for else
    public bool UpSwipe()
    {
        if (enable == true)
        {
            SwipeControl();

            if (currentSwipe.y > 0 && currentSwipe.x > -0.8f && currentSwipe.x < 0.8f && deltaVertical > 50)
            {
                currentSwipe = Vector2.zero;

                return true;
            }
        }
        
        return false;
    }

    // Define true if the player make the down swipe movement and false for else
    public bool DownSwipe()
    {
        if (enable == true)
        {
            SwipeControl();

            if (currentSwipe.y < 0 && currentSwipe.x > -0.8f && currentSwipe.x < 0.8f && deltaVertical < -50)
            {
                currentSwipe = Vector2.zero;

                return true;
            }
        }

        return false;
    }


    // Define 1 if the player press to rigth and -1 to left, or return 0 if not pressing
    public float HorizontalPress()
    {
        if (enable == true)
        {
            if (Input.touches.Length == 1)
            {
                touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    if (touch.position.x <= leftScreen)
                        return -1;
                    if (touch.position.x >= rightScreen)
                        return 1;
                }
            }
        }

        return 0;
    }

    // Define true if the player tap the screen and false for else
    public bool TapScreen()
    {
        if (enable == true)
        {
            if (Input.touches.Length > 0)
                return true;
        }

        return false;
    }

    // Compares the difference beteween the touches and return a minimun value
    public float Zoom()
    {
        if (Input.touchCount >= 2)
        {

            // Capture the curret and related position of the touches

            Vector2 fingerOnePos = Input.GetTouch(0).position;
            Vector2 fingerTwoPos = Input.GetTouch(1).position;
            Vector2 fingerOnePrevPos = Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition;
            Vector2 fingerTwoPrevPos = Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition;

            // Take the lengths beteween the difference under the vectors created 

            float currentMagnitude = (fingerOnePrevPos - fingerTwoPrevPos).magnitude;
            float magnitude = (fingerOnePos - fingerTwoPos).magnitude;

            // Compare the results again and return a value

            float difference = currentMagnitude - magnitude;

            float zoom = difference * 0.01f;

            return zoom;
        }
        return 0;
    }

    // Rocognize touches on the screen
    public void Enable()
    {
        enable = true;
    }

    // Don't rocognize touches on the screen
    public void Disable()
    {
        enable = false;
    }

    // Calculate the movement of the swipe
    private void CurrentSwipe(Vector2 currentPos)
    {
        currentSwipe = new Vector2(currentPos.x - firstPos.x, currentPos.y - firstPos.y);

        currentSwipe.Normalize();
    }

    // View the devices's screen size and define where will be the right and left touches
    public void screenSizeResolution() {
        leftScreen = ((Screen.width / 5) * 2);
        rightScreen = Screen.width - leftScreen;
    }

    public void OpenDialogue()
    {
        dialogueOpened = true;
    }

    public void CloseDialogue()
    {
        dialogueOpened = false;
    }

    public bool getDialogue()
    {
        return dialogueOpened;
    }
}
