using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public int score = 0;
    private int totalPickups = 10;
    public Text scoreText;
    public Text statsText;
    public Text timerText;
    private float timeLimit = 60f; // 1 minute time limit
    private bool isGameOver = false;

    private void Start()
    {
        timerText.text = "Time Left: " + Mathf.CeilToInt(timeLimit);
    }

    private void Update()
    {
        if (!isGameOver)
        {
            timeLimit -= Time.deltaTime;
            timerText.text = "Time Left: " + Mathf.CeilToInt(timeLimit);

            if (timeLimit <= 0)
            {
                isGameOver = true;
                GameOver();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           score++;

           scoreText.text = "Score: " + score;

            Destroy(gameObject);

            if (score == totalPickups && !isGameOver)
            {
                isGameOver = true;
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        if (score == totalPickups)
        {
            statsText.text = "Congratulations!\nYou collected all items: " + score;
        }
        else
        {
            statsText.text = "Time is Up!\nItems collected: " + score;
        }
    }
}
