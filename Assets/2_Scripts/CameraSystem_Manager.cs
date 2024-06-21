using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem_Manager : MonoBehaviour
{
    public static CameraSystem_Manager Instance;

    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private float arriveDist = .1f;
    public void Init_Func()
    {
        Instance = this;
    }

    public void OnFollow_Func(Vector2 _targetPos)
    {
        StartCoroutine(this.OnFollow_Cor(_targetPos));
    }

    private IEnumerator OnFollow_Cor(Vector2 _targetPos)
    {
        while (this.arriveDist < Vector3.Distance(this.transform.position, _targetPos))
        {
            this.transform.position = Vector3.Lerp(this.transform.position, _targetPos, Time.deltaTime * this.followSpeed);

            yield return null;
        }
    }
}
