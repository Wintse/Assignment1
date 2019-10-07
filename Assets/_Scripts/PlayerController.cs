using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

/*
 * Victoria Liu
 * player controller
 * moves the player
 * shoots the bullet game object when the mouse is clicked
 */
public class PlayerController : MonoBehaviour
{
    //speed and boundary
    public float speed;
    public Boundary boundary;
    //bullet shooting settings. the bullet object, spawn and fire rate
    [Header("shooting settings")]
    public GameObject bullet;
    public GameObject bulletspawn;
    public float fireRate = 0.5f;
    

    //rigidbody
    private Rigidbody2D rbody;
    public float myTime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //for firing the bullet. will move it in the y direction up
        //multiplies by units per second
        myTime += Time.deltaTime;
        if(Input.GetButton("Fire1") && myTime > fireRate)
        {
            //bullet's position and orientation 
            Instantiate(bullet, bulletspawn.transform.position, bulletspawn.transform.rotation);
            myTime = 0.0f;
            
        }
        Checkbounds();

    }

    void FixedUpdate()
    {
        //reads input of horizontal and vertical
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horiz, vert);
        //moves the player
        rbody.velocity = movement * speed;

    }

    public void Checkbounds()
    {
        
        //checks the boundary and makes sure that it doesn't go out of them
        rbody.position = new Vector2(
            Mathf.Clamp(rbody.position.x, boundary.Left, boundary.Right),
            Mathf.Clamp(rbody.position.y, boundary.Bottom, boundary.Top));    

    }


}
