using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagerP5 : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scorePointText;
    public TextMeshProUGUI lifeText;
    public GameObject gameOverPanel;
    public GameObject GamePausePanel;
    private AudioSource music;

    public float spawnRate = 2;
    public float lives = 3;
    public int score;
    public bool gameOver = false;
    public bool inGame;

    // Start is called before the first frame update
    private void Start()
    {
        music = GetComponent<AudioSource>();
    }

    public void StartGame(int difficulty)
    {
        spawnRate *= difficulty;
        inGame = true;
        UpdateScore(0);
        
        StartCoroutine(SpawnTarget());
    }

    private void Update()
    {
        if(lives < 1)
        {
            lives = 0;
            gameOver = true;
            GameOver();
        }

        lifeText.text = "" + lives;

        GameOver();

        if (score < 1)
        {
            score = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && inGame)
        {
            GamePausePanel.SetActive(true);
            GamePaused();
        }
    }

    IEnumerator SpawnTarget()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToUpdate)
    {
        score += scoreToUpdate;
        scorePointText.text = "" + score;
    }

    private void GameOver()
    {
        if (gameOver == true)
        {
            gameOverPanel.gameObject.SetActive(true);
            inGame = false;
        }
    }

    public void GamePaused()
    {
        Time.timeScale = 0;
    }

    public void GameResume()
    {
        Time.timeScale = 1;
    }
}
