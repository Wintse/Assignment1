using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

/*
 * Victoria Liu
 * bullet controller
 * moves the bullet when player shoots
 */

public class BulletController : MonoBehaviour
{
    //variables
    public float speed;
    public Boundary boundary;

    [Header("explosion settings")]
    public GameObject explosion;

    private Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        //move the bullet
        rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = transform.up * speed;
    }

    void Update()
    {
        //if bullet reaches the boundary destory it
        if (rbody.position.y > boundary.Top)
        {
            Destroy(this.gameObject);
        }
    }
    

}
