using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
 
public class DiamondsMove : MonoBehaviour
{
    Transform _dpanel;
    Sequence _diamondsmove;
    void Start()
    {
        Move();
    }
    void Move()
    {
        _dpanel = GameObject.FindGameObjectWithTag("finish").transform;
        _diamondsmove = DOTween.Sequence();
        _diamondsmove.Append(transform.DOMove(_dpanel.position, 2)
            .SetEase(Ease.OutSine));
    }
}
