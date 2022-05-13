using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    private Vector3 _firstTouchPosition;
    private Vector3 _curTouchPosition;
    [SerializeField] private float sensitivityMultiplier = 0.01f;
    private float _finalTouchX;
    private float _xBound = 2.58f;
    private bool _canMove = true;
    [SerializeField] private bool TapToPlay;
    public GameObject PlayImg;
    public void GamePlay()
    {
        TapToPlay = true;
    }
    void FixedUpdate()
    {
       if (TapToPlay)
        {
            PlayImg.SetActive(false);
            transform.Translate(Vector3.forward * _speed * Time.fixedDeltaTime);
            if (Input.GetMouseButtonDown(0))
            {
                _firstTouchPosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                _curTouchPosition = Input.mousePosition;
                Vector2 touchDelta = (_curTouchPosition - _firstTouchPosition);
                _finalTouchX = (transform.position.x + (touchDelta.x * sensitivityMultiplier));
                _finalTouchX = Mathf.Clamp(_finalTouchX, -_xBound, _xBound);
                transform.position = new Vector3(_finalTouchX, transform.position.y, transform.position.z);
                _firstTouchPosition = Input.mousePosition;
            }
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "stop")
        {
            TapToPlay = false;
            NextPlatfrom();
        }
        if (collision.gameObject.tag == "stop2")
        {
            TapToPlay = false;
            NextPlatfrom();
        }
        if (collision.gameObject.tag == "finish")
        {
            TapToPlay = false;
        }
    }
    IEnumerator NextPlatfrom()
    {
        yield return new WaitForSeconds(2);
        TapToPlay = true;
    }
}