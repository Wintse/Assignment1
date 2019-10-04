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
        
    }
    public void Checkbounds()
    {

        //checks the boundary
        rbody.position = new Vector2(
            Mathf.Clamp(rbody.position.x, boundary.Left, boundary.Right),
            Mathf.Clamp(rbody.position.y, boundary.Bottom, boundary.Top));

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);

        }
        Instantiate(explosion, this.transform.position, this.transform.rotation);
        Destroy(other.gameObject);
        Destroy(this.gameObject);
        //Destroy(explosion.gameObject);

    }

}
