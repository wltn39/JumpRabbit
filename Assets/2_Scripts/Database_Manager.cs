using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Database_Manager : ScriptableObject
{
    public static Database_Manager Instance;

    [Header("연출")]
    public Color scoreColor;
    public Color bonusColor;
    public float scorePopInterval;


    [Header("플레이어")]
    public float jumpPower = 1f;

    [Header("플랫폼")]
    public Platform_Script[] largePlatformClassArr = null;
    public Platform_Script[] middlePlatformClassArr = null;
    public Platform_Script[] smallPlatformClassArr = null;

    public PlatformSystem_Manager.Data[] dataArr = null;
    public float gapIntervalMin = .5f;
    public float gapIntervalMax = 1.5f;
    public float bonusValue = .05f;

    [Header("카메라")]
    public float followSpeed = 5f;
    public float arriveDist = .1f;

    [Header("아이템")]
    public Item_Script baseItemClass;
    public float itemSpawnPer = .2f;
    public float itemBonus = .25f;

    [Header("사운드")]
    [SerializeField] private BgmData[] bgmDataArr = null;
    [SerializeField] private SfxData[] sfxDataArr = null;
    private Dictionary<BgmType, BgmData> bgmDataDic;
    private Dictionary<SfxType, SfxData> sfxDataDic;
    public void Init_Func()
    {
        Instance = this;

        this.bgmDataDic = new Dictionary<BgmType, BgmData>();
        foreach (var _bgmData in this.bgmDataArr)
        {
            this.bgmDataDic.Add(_bgmData.bgmType, _bgmData);
        }

        this.sfxDataDic = new Dictionary<SfxType, SfxData>();
        foreach (var _sfxData in this.sfxDataArr)
        {
            this.sfxDataDic.Add(_sfxData.sfxType, _sfxData);
        }
    }

    public BgmData GetBgmData_Func(BgmType _bgmType)
    {
        return this.bgmDataDic[_bgmType];
    }
    public SfxData GetSfxData_Func(SfxType _sfxType)
    {
        return this.sfxDataDic[_sfxType];
    }

    [System.Serializable]
    public class SoundData
    {
        public AudioClip clip;
        public float volume = 1f;
    }


    [System.Serializable]
    public class BgmData : SoundData
    {
        public BgmType bgmType;
    }

    [System.Serializable]
    public class SfxData : SoundData
    {
        public SfxType sfxType;
    }
}

public enum BgmType
{
    None = 0,
    Main = 10,
}

public enum SfxType
{
    None = 0,

    Jump1 = 10,
    Jump2 = 20,
}
