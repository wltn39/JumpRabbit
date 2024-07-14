using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLanding : MonoBehaviour
{
    public static PlatformLanding Instance;
    [SerializeField] private Animation anim = null;

    public void LanddingEffect()
    {
        this.anim.Play();
    }
}
