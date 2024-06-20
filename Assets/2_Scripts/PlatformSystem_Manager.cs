using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSystem_Manager : MonoBehaviour
{
    [SerializeField] private Platform_Script[] largePlatformClassArr = null;
    [SerializeField] private Platform_Script[] middlePlatformClassArr = null;
    [SerializeField] private Platform_Script[] smallPlatformClassArr = null;

    private Dictionary<int, Platform_Script[]> paltformClassArrDic;

    public void Init_Func()
    {
        this.paltformClassArrDic.Add(0, this.smallPlatformClassArr);
        this.paltformClassArrDic.Add(0, this.middlePlatformClassArr);
        this.paltformClassArrDic.Add(0, this.largePlatformClassArr);
    }
    public void Activate_Func()
    {
        Platform_Script[] _platformClassArr = this.paltformClassArrDic[2];

        int _randID = Random.Range(0, _platformClassArr.Length);
        Platform_Script _randPlatformClass = _platformClassArr[_randID];

        Platform_Script _platformClass = GameObject.Instantiate<Platform_Script>(_randPlatformClass);
        Vector2 _pos = default;
        _platformClass.Activate_Func(_pos);
    }
}
