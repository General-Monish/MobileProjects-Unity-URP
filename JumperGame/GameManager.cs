using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject obstacles;

    int score = 0;

    [SerializeField] GameObject playButton;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        // Hide the play button
        playButton.SetActive(false);
        StartCoroutine("SpawnObstacles");
        InvokeRepeating("UpdateScore", 1f, 1f); // Update score every second  

    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // Check if the game is running
            float waitTime = Random.Range(0.5f, 1.5f);
            yield return new WaitForSeconds(waitTime);
            Instantiate(obstacles, spawnPoint.position, Quaternion.identity);
        }
    }

    void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
