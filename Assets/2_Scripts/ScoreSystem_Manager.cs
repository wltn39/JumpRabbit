using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem_Manager : MonoBehaviour
{
    public static ScoreSystem_Manager Instance;

    [SerializeField] private TextMeshProUGUI scoreTmp = null;
    [SerializeField] private TextMeshProUGUI bonusTmp = null;
    [SerializeField] private Score_Script baseScoreClass = null;
    private List<ScoreData> scoreDataList;

    private int totalScore;
    private float totalBonus;

    public void Init_Func()
    {
        Instance = this;
        this.scoreDataList = new List<ScoreData>();
    }

    public void Activate_Func()
    {
        this.totalBonus = 1f;
    }

    private IEnumerator OnScore_Cor()
    {
        while (true)
        {
            if (0 < this.scoreDataList.Count)
            {
                for (int i = this.scoreDataList.Count - 1; i >= 0; i--)
                {
                    ScoreData _scoreData = this.scoreDataList[i];

                    Score_Script _scoreClass = GameObject.Instantiate<Score_Script>(this.baseScoreClass);
                    _scoreClass.Activate_Func(_scoreData.str, _scoreData.color);

                    this.scoreDataList.RemoveAt(i);
                }
            }
            yield return null;
        }
    }
    public void AddScore_Func(int _score, Vector2 _scorePos)
    {
        ScoreData _scoreData = new ScoreData();
        _scoreData.str = _score.ToString();
        _scoreData.color = Database_Manager.Instance.scoreColor;
        _scoreData.pos = _scorePos;

        this.totalScore += _score;
        this.scoreTmp.text = this.totalScore.ToString();
    }

    public void AddBonus_Func(float _bonus, Vector2 _bonusPos)
    {
        Score_Script _scoreClass = GameObject.Instantiate<Score_Script>(this.baseScoreClass);
        _scoreClass.transform.position = _bonusPos;

        string _str = "Bonus " + _bonus.ToString_Percent_Func();
        _scoreClass.Activate_Func(_str, Database_Manager.Instance.bonusColor);

        this.totalBonus += _bonus;
        this.bonusTmp.text = this.totalBonus.ToString_Percent_Func();
    }

    public void OnResetBonus_Func()
    {
        this.totalBonus = 1f;
        this.bonusTmp.text = this.totalBonus.ToString_Percent_Func();
    }

    private struct ScoreData
    {
        public string str;
        public Color color;
        public Vector2 pos;
    }
}
