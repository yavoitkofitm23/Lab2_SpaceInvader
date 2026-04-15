using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text scoreText;
    public Text messageText;
    public Text hpText;
    public GameObject restartBtn;

    int score = 0;
    bool gameOver = false;

    void Awake()
    {
        instance = this;
        Time.timeScale = 1;
    }

    void Start()
    {
        messageText.text = "";
        scoreText.text = "Score: 0";
        restartBtn.SetActive(false);
        restartBtn.GetComponent<Button>().onClick.AddListener(Restart);
    }

    public void AddScore(int points)
    {
        if (gameOver) return;
        score = score + points;
        scoreText.text = "Score: " + score;
    }

    public void UpdateHP(int hp)
    {
        hpText.text = "HP: " + hp;
    }

    public void Win()
    {
        gameOver = true;
        messageText.text = "YOU WIN!";
        Time.timeScale = 0;
        restartBtn.SetActive(true);
    }

    public void Lose()
    {
        gameOver = true;
        messageText.text = "GAME OVER";
        Time.timeScale = 0;
        restartBtn.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
