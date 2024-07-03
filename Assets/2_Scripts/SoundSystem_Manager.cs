using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem_Manager : MonoBehaviour
{
    public static SoundSystem_Manager Instance;

    [SerializeField] private AudioSource bgmAS = null;
    [SerializeField] private AudioSource sfxAS = null;

    public void Init_Func()
    {
        Instance = this;
    }

    public void PlayBgm_Func(BgmType _bgmType)
    {
        Database_Manager.BgmData _bgmData = Database_Manager.Instance.GetBgmData_Func(_bgmType);
        this.bgmAS.clip = _bgmData.clip;
        this.bgmAS.volume = _bgmData.volume;
        this.bgmAS.Play();
    }
    public void PlaySfx_Func(SfxType _sfxType)
    {
        Database_Manager.SfxData _sfxData = Database_Manager.Instance.GetSfxData_Func(_sfxType);
        this.sfxAS.volume = _sfxData.volume;
        this.sfxAS.PlayOneShot(_sfxData.clip);
    }
}
