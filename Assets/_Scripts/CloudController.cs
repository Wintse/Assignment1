using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class CloudController : MonoBehaviour
{
    [SerializeField]
    public Speed horizSpeedRange;
    [SerializeField]
    public Speed vertiSpeedRange;

    public float vertiSpeed;
    public float horziSpeed;

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
        Vector2 newPosition = new Vector2(horziSpeed, vertiSpeed);
        Vector2 currentPosition = transform.position;

        currentPosition -= newPosition;
        transform.position = currentPosition;
    }

    void Reset()
    {
        horziSpeed = Random.Range(horizSpeedRange.min, horizSpeedRange.max);
        vertiSpeed = Random.Range(vertiSpeedRange.min, vertiSpeedRange.max);

        float randomXPos = Random.Range(boundary.Left, boundary.Right);
        transform.position = new Vector2(randomXPos, Random.Range(boundary.Top, boundary.Top + 2.0f));
    }

    void Checkbound()
    {
        if(transform.position.y <= boundary.Bottom)
        {
            Reset();
        }
    }

}
