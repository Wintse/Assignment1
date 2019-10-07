using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Victoria Liu
 * the boundary
 * can be used in multiple other areas so you dont have to continuously rewrite it
 */


namespace Util
{
    [System.Serializable]
    public class Boundary
    {
        //boundary, can be used in other code over and over
        public float Top;
        public float Right;
        public float Bottom;
        public float Left;
    }

}

