using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Victoria Liu
 * Grass controller
 * from Tom's code from Mail Pilot
 * moves the background so it looks like it is moving
 */
public class GrassController : MonoBehaviour
{
    //variables of speeeed
    public float vSpeed = 0.3f;
    public float resetPos = 5.0f;
    public float resetPoint = -5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    //for moving the grass
    void Move()
    {
        //new position and finding the current position
        Vector2 newPosition = new Vector2(0.0f, vSpeed);
        Vector2 currentPosition = transform.position;
        //moves the grass to the new position by subtracking the 
        currentPosition -= newPosition;
        transform.position = currentPosition;

    }

    void Reset()
    {
        //resets the position of grass
        transform.position = new Vector2(0.0f, resetPos);
    }
    void CheckBounds()
    {
        //check the boundaries to see when it should call the reset function.
        if(transform.position.y <= resetPoint)
        {
            Reset();
        }
    }


}
