using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem_Manager : MonoBehaviour
{
    public static ScoreSystem_Manager Instance;

    [SerializeField] private TextMeshProUGUI scoreTmp = null;
    [SerializeField] private Score_Script baseScoreClass = null;

    private int totalScore;
    public void Init_Func()
    {
        Instance = this;
    }

    public void AddScore_Func(int _score, Vector2 _scorePos)
    {
        Score_Script _scoreClass = GameObject.Instantiate<Score_Script>(this.baseScoreClass);
        _scoreClass.transform.position = _scorePos;
        _scoreClass.Activate_Func(_score);

        this.totalScore += _score;
        this.scoreTmp.text = this.totalScore.ToString();
    }
}
