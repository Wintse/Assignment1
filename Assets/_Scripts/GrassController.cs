using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassController : MonoBehaviour
{
    //variables
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
        Vector2 newPosition = new Vector2(0.0f, vSpeed);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;

    }

    void Reset()
    {
        transform.position = new Vector2(0.0f, resetPos);
    }
    void CheckBounds()
    {
        if(transform.position.y <= resetPoint)
        {
            Reset();
        }
    }


}
