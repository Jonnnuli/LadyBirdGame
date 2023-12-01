using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Player class
 * Jonna Helaakoski 2023
 */
public class Player : MonoBehaviour
{
    public GameObject food;
    public float movingSpeed;
    Rigidbody2D rb;

    float directionX;
    float moveSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        directionX = Input.acceleration.x * moveSpeed; //When the mobile phone is tilted, player moves left or right.
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y); //Player can't go outside the screen.
    }

    //Fixes frame update.
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(directionX, 0f);
    }

    //When the player and enemy collides, scene is loaded.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(0);
        }
    }
}
