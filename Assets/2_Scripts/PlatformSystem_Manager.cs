using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlatformSystem_Manager : MonoBehaviour
{
    [SerializeField] private Transform spawnPosTrf = null;
    [SerializeField] private Platform_Script[] largePlatformClassArr = null;
    [SerializeField] private Platform_Script[] middlePlatformClassArr = null;
    [SerializeField] private Platform_Script[] smallPlatformClassArr = null;
    private Dictionary<int, Platform_Script[]> platformClassArrDic;

    public void Init_Func()
    {
        this.platformClassArrDic = new Dictionary<int, Platform_Script[]>();

        this.platformClassArrDic.Add(0, this.smallPlatformClassArr);
        this.platformClassArrDic.Add(1, this.middlePlatformClassArr);
        this.platformClassArrDic.Add(2, this.largePlatformClassArr);
    }
    public void Activate_Func()
    {
        // LargePlatform
        Platform_Script[] _platformClassArr = this.platformClassArrDic[2];
        Vector2 _pos = this.spawnPosTrf.position;

        for (int i = 0; i < 5; i++)
        {
            int _randID = Random.Range(0, _platformClassArr.Length);
            Platform_Script _randPlatformClass = _platformClassArr[_randID];

            Platform_Script _platformClass = GameObject.Instantiate<Platform_Script>(_randPlatformClass);
            _platformClass.Activate_Func(_pos);

            _pos += Vector2.right * 6f;
        }

        // middlePlatform
        _platformClassArr = this.platformClassArrDic[1];

        for (int i = 0; i < 5; i++)
        {
            int _randID = Random.Range(0, _platformClassArr.Length);
            Platform_Script _randPlatformClass = _platformClassArr[_randID];

            Platform_Script _platformClass = GameObject.Instantiate<Platform_Script>(_randPlatformClass);
            _platformClass.Activate_Func(_pos);

            _pos += Vector2.right * 6f;
        }

        // smallPlatform
        _platformClassArr = this.platformClassArrDic[0];

        for (int i = 0; i < 5; i++)
        {
            int _randID = Random.Range(0, _platformClassArr.Length);
            Platform_Script _randPlatformClass = _platformClassArr[_randID];

            Platform_Script _platformClass = GameObject.Instantiate<Platform_Script>(_randPlatformClass);
            _platformClass.Activate_Func(_pos);

            _pos += Vector2.right * 6f;
        }
    }
}
