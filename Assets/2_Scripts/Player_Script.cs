using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigid = null;
    [SerializeField] private float jumpPower = 1f;

    public void Init_Func()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true) // 입력값
        {
            this.rigid.AddForce(Vector2.one * .5f * this.jumpPower);
        }
    }
}

