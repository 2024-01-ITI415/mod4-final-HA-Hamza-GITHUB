using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public int score = 0;
    public int totalPickups = 10;
    public Text scoreText;
    public Text statsText;
    public Text timerText;

    private float timeLimit = 60f; // 1 minute time limit
    private bool isGameOver = false;

    private void Start(){
        statsText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            score++;
            Destroy(other.gameObject); // Destroy the pickup object
            UpdateUI();

            if (score == totalPickups && !isGameOver)
            {
                isGameOver = true;
                GameOver();
                statsText.gameObject.SetActive(true);
            }
        }
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
                statsText.gameObject.SetActive(true);
            }
        }
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
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
