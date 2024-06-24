using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid = null;
    private float currentJumpPower = 1f;
    [SerializeField] private Animator anim = null;

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
        }
    }


    private void OnCollisionEnter2D(Collision2D _col)
    {
        this.rigid.velocity = Vector2.zero;
        this.anim.SetInteger("StateID", 0);
        CameraSystem_Manager.Instance.OnFollow_Func(this.transform.position);

        if (_col.transform.parent.TryGetComponent(out Platform_Script _platformClass) == true)
        {
            _platformClass.OnLanding_Func();
        }
    }
}



