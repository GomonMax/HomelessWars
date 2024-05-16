using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator _animName;

    public void animationNameOpen()
    {
        _animName.SetBool("Open", true);
        _animName.SetBool("Close", false);
    }
    public void animationNameClose()
    {
        _animName.SetBool("Close", true);
        _animName.SetBool("Open", false);
    }
}
