using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int score;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }
    public void AddScore(int value)
    {
        score += value;
    }

    public void ResetScore()
    {
        score = 0;
    }
}