using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Script : MonoBehaviour
{

    [SerializeField] private BoxCollider2D col = null;
    [SerializeField] private SpriteRenderer srdr = null;

    public void Activate_Func(Vector2 _pos)
    {
        this.transform.position = _pos;
    }
}
