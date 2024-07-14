using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Script : MonoBehaviour
{

    [SerializeField] private BoxCollider2D col = null;
    [SerializeField] private SpriteRenderer srdr = null;
    [SerializeField] private int score;

    public float GetHalfSizeX => this.col.size.x * 0.5f;
    public void Activate_Func(Vector2 _pos)
    {
        this.transform.position = _pos;
        if (Random.value < Database_Manager.Instance.itemSpawnPer)
        {
            Item_Script _itemClass = GameObject.Instantiate<Item_Script>(Database_Manager.Instance.baseItemClass);
            _itemClass.Activate_Func(this.transform.position, this.GetHalfSizeX);
        }
    }

    public void OnLanding_Func()
    {
        ScoreSystem_Manager.Instance.AddScore_Func(this.score, this.transform.position);
        PlatformLanding.Instance.LanddingEffect();
    }
}
