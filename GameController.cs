using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text restartText;
    public Text winText;
    public Text gameOverText;
    public Text hardModeText;

    private bool gameOver;
    private bool restart;
    private bool hardMode;
    public bool winCondition;
    public int score;

    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;

    public AudioSource musicSource;

    public string NewLine { get; private set; }

    void Start()
    {
        gameOver = false;
        restart = false;
        winCondition = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                SceneManager.LoadScene("Main2");
            }
        }
        if (Input.GetKey("escape"))
            Application.Quit();

        if (hardMode)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                SceneManager.LoadScene("HardMode");
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'L' for Restart";
                hardModeText.text = "Press 'H' for Hard Mode";
                restart = true;
                hardMode = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 100)
          {
            gameOverText.text = "You win! Game Created by Heather Raymond";
            gameOver = true;
            restart = true;
            winCondition = true;
            musicSource.clip = musicClipOne;
            musicSource.Play();
           }
      }
    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
        musicSource.clip = musicClipTwo;
        musicSource.Play();
    }
}