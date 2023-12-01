using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

/** GameManager counts score and spawns enemy and food (bugs).
 *  Jonna Helaakoski 2023
 */
public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject food;
    public GameObject player;
    public float XMaxPoint;
    public Transform spawnPoint;
    public float spawnRate;

    bool gameStarted = false;
    
    public GameObject startText;
    public GameObject guideText;
    public int score = 0;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted) //when screen is touched, game starts.
        {
            StartSpawning();
            gameStarted = true;
            startText.SetActive(false);
            guideText.SetActive(false);
        }
    }

    // StartSpawning - calls SpawnEnemy and SpawnFood to make enemy and food to fall.
    private void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", 0.7f, spawnRate);
        InvokeRepeating("SpawnFood", 0.5f, spawnRate);
    }

    // SpawnFood - makes food to fall from random x point above the screen.
    private void SpawnFood()
    {
        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(-XMaxPoint, XMaxPoint);

        Instantiate(food, spawnPos, Quaternion.identity);
    }

    // SpawnEnemy - makes enemy to fall from random x point above the screen.
    private void SpawnEnemy()
    {
        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(-XMaxPoint, XMaxPoint);

        Instantiate(enemy, spawnPos, Quaternion.identity);
    }

    // CountScore - counts how many food (bugs) the player has eaten.
    public void CountScore()
    {
        score++;
        scoreText.text = score.ToString(); 
    }
}
