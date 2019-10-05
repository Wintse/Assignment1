using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class CloudController : MonoBehaviour
{
    //range of speed for horizontal and vertical
    [SerializeField]
    public Speed horizSpeedRange;
    [SerializeField]
    public Speed vertiSpeedRange;

    //vertical and horizontal speed
    public float vertiSpeed;
    public float horziSpeed;

    //boundary controller to set boundaries
    [SerializeField]
    public Boundary boundary;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Checkbound();
    }

    void Move()
    {
        //move the position of cloud based on vertical and horizontal speed
        Vector2 newPosition = new Vector2(horziSpeed, vertiSpeed);
        Vector2 currentPosition = transform.position;
        //move from current position to new position
        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    void Reset()
    {
        //randomly generate speed based on range
        horziSpeed = Random.Range(horizSpeedRange.min, horizSpeedRange.max);
        vertiSpeed = Random.Range(vertiSpeedRange.min, vertiSpeedRange.max);
        //reset to that new position
        float randomXPos = Random.Range(boundary.Left, boundary.Right);
        transform.position = new Vector2(randomXPos, Random.Range(boundary.Top, boundary.Top + 2.0f));
    }

    void Checkbound()
    {
        //if cloud is outside of boundary call reset
        if(transform.position.y <= boundary.Bottom)
        {
            Reset();
        }
    }

}
