using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem_Manager : MonoBehaviour
{
    public static ScoreSystem_Manager Instance;
    private int totalScore;
    public void Init_Func()
    {
        Instance = this;
    }

    public void AddScore_Func(int _score)
    {
        this.totalScore += _score;
    }
}
