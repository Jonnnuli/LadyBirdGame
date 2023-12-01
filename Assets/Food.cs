using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/** Food class
 *  Jonna Helaakoski 2023
 */
public class Food : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -6f) //When food goes outside the screen, food is destroyed.
        {
            Destroy(gameObject);
        }
    }

    // When food hits player, GameManager CountScore is called and food game object is destroyed.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.CountScore();

            Destroy(gameObject);
        }
    }
}
