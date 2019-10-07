using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Victoria Liu
 * destroy object
 * destroy's items such as bullet and explosion after they are used
 */
public class DestroyObject : MonoBehaviour
{
    public void DestroyThis()
    {
        //destroys bullet and explosion
        Destroy(this.gameObject);
    }
}
