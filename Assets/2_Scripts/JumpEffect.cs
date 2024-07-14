using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JumpEffect : MonoBehaviour
{
    public void Activate_Func(Vector3 _pos)
    {
        this.transform.position = _pos;
    }

    public void CallAni_Func()
    {
        GameObject.Destroy(this.gameObject);
    }
}
