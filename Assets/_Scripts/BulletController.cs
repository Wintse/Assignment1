using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;
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
        rbody = GetComponent<Rigidbody2D>();
        rbody.velocity = transform.up * speed;
    }

    void Update()
    {
        Checkbounds();
    }
    public void Checkbounds()
    {

        if (rbody.position.y > boundary.Top)
        {
            Destroy(this.gameObject);
        }

    }

}
