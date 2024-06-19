using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem_Manager : MonoBehaviour
{
    [SerializeField] private Player_Script PlayerClass = null;

    private void Awake()
    {
        this.PlayerClass.Init_Func();
    }
    
}
