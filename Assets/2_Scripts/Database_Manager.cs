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


    public void Init_Func()
    {
        Instance = this;
    }
}
