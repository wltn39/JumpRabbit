using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Script : MonoBehaviour
{
    [SerializeField] private TextMeshPro tmp = null;
    public void Activate_Func(string _str, Color _color)
    {
        this.tmp.text = _str;
        this.tmp.color = _color;
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
