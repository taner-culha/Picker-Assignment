using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenAnim : MonoBehaviour
{
    Animator _oL,_oR;
    bool _openLeft,_openRight;
    void Start()
    {
        _oL = gameObject.GetComponent<Animator>();
        _oR = gameObject.GetComponent<Animator>();
        _openLeft = false;
        _openRight = false;
    }
    public void OpenLeft()
    {
        _openLeft = true;
        _oL.SetBool("openLeft", true);
    }
    public void OpenRight()
    {
        _openRight = true;
        _oR.SetBool("openRight", true);
    }
}
