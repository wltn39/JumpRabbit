using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid = null;
    [SerializeField] private Animator anim = null;
    private float currentJumpPower = 1f;
    private Platform_Script landingPlatformClass;


    public void Init_Func()
    {

    }

    private void Update()
    {
        // 입력값
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            this.anim.SetInteger("StateID", 1);
        }
        else if (Input.GetKey(KeyCode.Space) == true)
        {
            this.currentJumpPower += Database_Manager.Instance.jumpPower;
        }
        else if (Input.GetKeyUp(KeyCode.Space) == true)
        {
            this.rigid.AddForce(Vector2.one * .5f * this.currentJumpPower);

            this.currentJumpPower = 0f;

            this.anim.SetInteger("StateID", 2);

            SfxType _sfxType = Random.value < .5f ? SfxType.Jump1 : SfxType.Jump2;
            SoundSystem_Manager.Instance.PlaySfx_Func(_sfxType);

            JumpEffect _effClass = GameObject.Instantiate<JumpEffect>(Database_Manager.Instance.effClass);
            _effClass.Activate_Func(this.transform.position);
        }
    }


    private void OnCollisionEnter2D(Collision2D _col)
    {
        this.rigid.velocity = Vector2.zero;

        this.anim.SetInteger("StateID", 0);



        Transform _parentTrf = _col.transform.parent;
        if (_parentTrf != null && _parentTrf.TryGetComponent(out Platform_Script _platformClass) == true)
        {
            CameraSystem_Manager.Instance.OnFollow_Func(this.transform.position);

            if (this.landingPlatformClass != _platformClass)
            {
                this.landingPlatformClass = _platformClass;
                ScoreSystem_Manager.Instance.AddBonus_Func(Database_Manager.Instance.bonusValue, this.transform.position);
            }
            else
            {
                ScoreSystem_Manager.Instance.OnResetBonus_Func(this.transform.position);
            }
            _platformClass.OnLanding_Func();

        }
    }
}



