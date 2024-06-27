using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Item_Script : MonoBehaviour
{
  public void Activate_Func(Vector2 _pos, float _rangeX)
  {
    float _x = Random.Range(-_rangeX, _rangeX) + _pos.x;
    this.transform.position = new Vector3(_x, _pos.y, 0f);
  }

  private void OnCollisionEnter2D(Collision2D _col)
  {
    if (_col.transform.TryGetComponent(out Player_Script _playerClass) == true)
    {
      // 보너스 증가 
      float _itemBonus = Database_Manager.Instance.itemBonus;
      Vector3 _thisPos = this.transform.position;
      ScoreSystem_Manager.Instance.AddBonus_Func(_itemBonus, _thisPos);

      GameObject.Destroy(this.gameObject);
    }
  }
}
