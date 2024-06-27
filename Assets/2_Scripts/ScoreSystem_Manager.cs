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
        StartCoroutine(this.OnScore_Cor());
    }

    private IEnumerator OnScore_Cor()
    {
        while (true)
        {
            if (0 < this.scoreDataList.Count)
            {
                ScoreData _scoreData = this.scoreDataList[0];

                Score_Script _scoreClass = GameObject.Instantiate<Score_Script>(this.baseScoreClass);
                _scoreClass.Activate_Func(_scoreData.str, _scoreData.color);
                _scoreClass.transform.position = _scoreData.pos;

                this.scoreDataList.RemoveAt(0);

                yield return new WaitForSeconds(Database_Manager.Instance.scorePopInterval);
            }
            else
            {
                yield return null;
            }

        }
    }
    public void AddScore_Func(int _score, Vector2 _scorePos, bool _isCalcBonus = true)
    {
        ScoreData _scoreData = new ScoreData();
        _scoreData.str = _score.ToString();
        _scoreData.color = Database_Manager.Instance.scoreColor;
        _scoreData.pos = _scorePos;
        this.scoreDataList.Add(_scoreData);

        this.totalScore += _score;

        if (_isCalcBonus == true)
        {
            int _bonusScore = (int)(_score * this.totalBonus);
            this.AddScore_Func(_bonusScore, _scorePos, false);
        }

        this.scoreTmp.text = this.totalScore.ToString();
    }

    public void AddBonus_Func(float _bonus, Vector2 _bonusPos)
    {
        ScoreData _scoreData = new ScoreData();
        _scoreData.str = "Bonus " + _bonus.ToString_Percent_Func();
        _scoreData.color = Database_Manager.Instance.bonusColor;
        _scoreData.pos = _bonusPos;
        this.scoreDataList.Add(_scoreData);

        this.totalBonus += _bonus;

        this.bonusTmp.text = this.totalBonus.ToString_Percent_Func();
    }

    public void OnResetBonus_Func(Vector2 _pos)
    {
        this.totalBonus = 0f;
        this.bonusTmp.text = this.totalBonus.ToString_Percent_Func();

        ScoreData _scoreData = new ScoreData();
        _scoreData.str = "Bonus 초기화 ...";
        _scoreData.color = Database_Manager.Instance.bonusColor;
        _scoreData.pos = _pos;
        this.scoreDataList.Add(_scoreData);


    }

    private struct ScoreData
    {
        public string str;
        public Color color;
        public Vector2 pos;
    }
}
