using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float maxX = 3f;
    public GameObject Obstacle;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject tapText;
    public GameObject title;
    public Transform spawnPoints;
    bool isGameStarted = false;

    bool gameover = false;

    public GameObject gameOverUI;


    int score = 0;
    int highscore = 0;



    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && !isGameStarted)
        {
            isGameStarted = true;
            tapText.SetActive(false);
            title.SetActive(false);
            StartCoroutine(Spawn());

        }
    }

    IEnumerator Spawn()
    {
        while (!gameover)
        {
            gameOverUI.SetActive(false);

            Vector3 spawnPos = spawnPoints.position;
            spawnPos.x = Random.Range(-maxX, maxX);
            spawnPos.y += 2.5f;

            Instantiate(Obstacle, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0.5f, 3f));

            score++;
            scoreText.text = score.ToString();
        }
    }

    public void GameOver()
    {
        gameover=true;
        StopAllCoroutines();
        if (score > highscore)
        {
            highscore=score;
            PlayerPrefs.SetInt("HighScore",highscore);
            PlayerPrefs.Save();
        }

        highScoreText.text="HighScore: "+ highscore.ToString();
        gameOverUI.SetActive(true);

    }

    public void Retry(){
        SceneManager.LoadScene("MainGame"); 
        Debug.Log("Restarting");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
