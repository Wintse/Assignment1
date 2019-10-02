using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{

    public Speed speed;
    public Boundary boundary;

    public GameController gameController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Checkbounds();
    }

    public void Move()
    {
        Vector2 newPosition = transform.position;

        //horizontal
        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            newPosition += new Vector2(speed.max, 0.0f);
        }

        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            newPosition += new Vector2(speed.min, 0.0f);
        }

        //vertical
        if (Input.GetAxis("Vertical") > 0.0f)
        {
            newPosition += new Vector2(speed.max, 0.0f);
        }
        if( Input.GetAxis("Vertical") > 0.0f)
        {
            newPosition += new Vector2(speed.min, 0.0f);
        }


        transform.position = newPosition;
    }

    public void Checkbounds()
    {
        //check boundary for all sides
        if (transform.position.x > boundary.Right)
        {
            transform.position = new Vector2(boundary.Right, transform.position.y);
        }
        if (transform.position.x < boundary.Left)
        {
            transform.position = new Vector2(boundary.Left, transform.position.y);
        }
        if (transform.position.y < boundary.Top)
        {
            transform.position = new Vector2(transform.position.x, boundary.Top);
        }
        if (transform.position.y < boundary.Bottom)
        {
            transform.position = new Vector2(transform.position.x, boundary.Bottom);
        }

    }

}
