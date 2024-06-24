using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Script : MonoBehaviour
{
    [SerializeField] private TextMeshPro tmp = null;

    public void Activate_Func(int _score)
    {
        this.tmp.text = _score.ToString();
    }
    public void Deactivate_Func()
    {
        GameObject.Destroy(this.gameObject);
    }
    public void CallAni_Decativate_Func()
    {
        this.Deactivate_Func();
    }
}
