using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlatformSystem_Manager : MonoBehaviour
{
    private Dictionary<int, Platform_Script[]> platformClassArrDic;
    private int platformNum;
    [SerializeField] private Transform spawnPosTrf = null;

    public void Init_Func()
    {
        this.platformClassArrDic = new Dictionary<int, Platform_Script[]>();

        this.platformClassArrDic.Add(0, Database_Manager.Instance.smallPlatformClassArr);
        this.platformClassArrDic.Add(1, Database_Manager.Instance.middlePlatformClassArr);
        this.platformClassArrDic.Add(2, Database_Manager.Instance.largePlatformClassArr);
    }
    public void Activate_Func()
    {
        Vector2 _pos = this.spawnPosTrf.position;

        for (int i = 0; i < 50; i++)
        {
            int _platformID = -1;

            foreach (Data _data in Database_Manager.Instance.dataArr)
            {
                if (_data.TryGetPlatformID_Func(this.platformNum, out _platformID) == true)
                {
                    break;
                }
            }
            // LargePlatform
            Platform_Script[] _platformClassArr = this.platformClassArrDic[_platformID];

            int _randID = Random.Range(0, _platformClassArr.Length);
            Platform_Script _randPlatformClass = _platformClassArr[_randID];

            Platform_Script _platformClass = GameObject.Instantiate<Platform_Script>(_randPlatformClass);

            if (i > 0)
                _pos += Vector2.right * _platformClass.GetHalfSizeX;

            _platformClass.Activate_Func(_pos);

            float _gap = Random.Range(Database_Manager.Instance.gapIntervalMin, Database_Manager.Instance.gapIntervalMax);

            _pos += new Vector2(_gap + _platformClass.GetHalfSizeX, 0f);

            this.platformNum++;
        }
    }

    [System.Serializable]
    public class Data
    {
        [SerializeField] private int conditionNum;
        [SerializeField] private float[] percentArr = new float[3];

        public bool TryGetPlatformID_Func(int _platformNum, out int _platformID)
        {
            if (this.conditionNum <= _platformNum)
            {
                float _randValue = Random.value;

                for (int i = 0; i < this.percentArr.Length; i++)
                {
                    if (_randValue < this.percentArr[i])
                    {
                        _platformID = i;
                        return true;
                    }
                    else
                    {
                        _randValue -= this.percentArr[i];
                    }
                }
                _platformID = 0;
                return true;
            }
            else
            {
                _platformID = -1;
                return false;
            }
        }
    }
}
