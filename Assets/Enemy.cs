using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Enemy class
 *  Jonna Helaakoski 2023
 */
public class Enemy : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -6f) //When enemy goes outside the screen, enemy is destroyed.
        {
            Destroy(gameObject);
        }
    }
}
