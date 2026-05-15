using System.Collections;
using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    private PlayerScore[] players;

    [SerializeField]
    private TextMeshProUGUI purpleBeastieScore;

    [SerializeField]
    private TextMeshProUGUI redBeastieScore;
void Start()
    {
        // find all objects with this component (query)
        players = FindObjectsByType<PlayerScore>(FindObjectsSortMode.None);
        StartCoroutine(WinnerRoutine());
        UpdateScoreUI();
    }

    private void Update()
    {
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        foreach (var p in players)
        {
            if (p.CompareTag("Purple"))
            {
                purpleBeastieScore.text = "Purple: " + p.Score;
            }

            if (p.CompareTag("Red"))
            {
                redBeastieScore.text ="Red: " + p.Score;
            }
        }
    }
    IEnumerator WinnerRoutine()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(60f);

            PlayerScore winner = GetWinner();

            if (winner != null)
            {
                Debug.Log("Winner score: " + winner.Score);
            }
        }
    }

    PlayerScore GetWinner()
    {
        PlayerScore[] players = FindObjectsByType<PlayerScore>(FindObjectsSortMode.None);

        PlayerScore best = null;

        foreach (var p in players)
        {
            if (best == null || p.Score > best.Score)
            {
                best = p;
            }
        }

        return best;
    }
}