using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Database_Manager : ScriptableObject
{
    public static Database_Manager Instance;

    [Header("Player")]
    public float jumpPower = 1f;

    [Header("PlatformSystem")]
    public Platform_Script[] largePlatformClassArr = null;
    public Platform_Script[] middlePlatformClassArr = null;
    public Platform_Script[] smallPlatformClassArr = null;

    public PlatformSystem_Manager.Data[] dataArr = null;
    public float gapIntervalMin = .5f;
    public float gapIntervalMax = 1.5f;

    [Header("Camera")]
    public float followSpeed = 5f;
    public float arriveDist = .1f;

    public void Init_Func()
    {
        Instance = this;
    }
}
