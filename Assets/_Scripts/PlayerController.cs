using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{
    //speed and boundary
    public float speed;
    public Boundary boundary;
    //bullet shooting settings
    [Header("shooting settings")]
    public GameObject bullet;
    public GameObject bulletspawn;
    public float fireRate = 0.5f;
    //explosion
    [Header("explosion settings")]
    public GameObject explosion;

    //rigidbody
    private Rigidbody2D rbody;
    public float myTime = 0.0f;


    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //for firing the bullet. will move it in the y direction
        //multiplies by units per second
        myTime += Time.deltaTime;
        if(Input.GetButton("Fire1") && myTime > fireRate)
        {
            //bullet
            Instantiate(bullet, bulletspawn.transform.position, bulletspawn.transform.rotation).GetComponent<Rigidbody>(); ;
            myTime = 0.0f;
            
        }
        Checkbounds();

    }

    void FixedUpdate()
    {
        //reads input
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horiz, vert);
        //moves the player
        rbody.velocity = movement * speed;

    }

    public void Checkbounds()
    {
        
        //checks the boundary
        rbody.position = new Vector2(
            Mathf.Clamp(rbody.position.x, boundary.Left, boundary.Right),
            Mathf.Clamp(rbody.position.y, boundary.Bottom, boundary.Top));    

    }


}
