using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem_Manager : MonoBehaviour
{
    [SerializeField]
    private PlatformSystem_Manager platformSystem_Manager = null;
    [SerializeField] private Player_Script PlayerClass = null;
    [SerializeField] private CameraSystem_Manager cameraSystem_Manager = null;
    [SerializeField] private Database_Manager database_Manager = null;
    [SerializeField] private ScoreSystem_Manager scoreSystem_Manager = null;

    private void Awake()
    {
        this.database_Manager.Init_Func();
        this.PlayerClass.Init_Func();
        this.platformSystem_Manager.Init_Func();
        this.cameraSystem_Manager.Init_Func();
        this.scoreSystem_Manager.Init_Func();
    }

    private void Start()
    {
        this.platformSystem_Manager.Activate_Func();
    }
}
