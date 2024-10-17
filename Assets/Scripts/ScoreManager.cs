using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int killScore;
    public TMP_Text enemyScore;


//---------------------------------------------------------------------//
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        RefreshScore();
    }

//--------------------------------------------------------------------//
    private void RefreshScore()
    {
        enemyScore.text = killScore.ToString();
    }

    public void AddScore(int amount)
    {
        killScore += amount;
    }
}
