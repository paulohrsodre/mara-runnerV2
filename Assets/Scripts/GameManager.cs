using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public static GameManager inst;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] PlayerMovement playerMovement;

    private void Awake() {
        inst = this;
    }

    public void IcrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }
}
