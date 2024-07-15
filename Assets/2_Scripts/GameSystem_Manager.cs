using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem_Manager : MonoBehaviour
{
    public static GameSystem_Manager Instance;
    [SerializeField] private PlatformSystem_Manager platformSystem_Manager = null;
    [SerializeField] private Player_Script PlayerClass = null;
    [SerializeField] private CameraSystem_Manager cameraSystem_Manager = null;
    [SerializeField] private Database_Manager database_Manager = null;
    [SerializeField] private ScoreSystem_Manager scoreSystem_Manager = null;
    [SerializeField] private SoundSystem_Manager soundSystem_Manager = null;
    [SerializeField] private SpriteRenderer bgSrdr = null;
    [SerializeField] private GameObject retryBtnObj = null;

    private void Awake()
    {
        Instance = this;
        this.database_Manager.Init_Func();
        this.PlayerClass.Init_Func();
        this.platformSystem_Manager.Init_Func();
        this.cameraSystem_Manager.Init_Func();
        this.scoreSystem_Manager.Init_Func();
        this.soundSystem_Manager.Init_Func();
    }

    private void Start()
    {
        this.platformSystem_Manager.Activate_Func();
        this.scoreSystem_Manager.Activate_Func();
        this.PlayerClass.Activate_Func();

        SoundSystem_Manager.Instance.PlayBgm_Func(BgmType.Main);
    }

    private void Update()
    {
        float _cameraPosX = CameraSystem_Manager.Instance.transform.position.x;
        this.bgSrdr.transform.position = new Vector3(10f + _cameraPosX, this.bgSrdr.transform.position.y, 0f);
        this.bgSrdr.size = new Vector2(25f + _cameraPosX * 2f, this.bgSrdr.size.y);
    }

    public void OnGameOver_Func()
    {
        this.retryBtnObj.SetActive(true);
    }

    public void CallBtn_Retry_Func()
    {
        if (this.retryBtnObj.activeSelf == true)
            UnityEngine.SceneManagement.SceneManager.LoadScene("JR_GameScene");
    }
}
