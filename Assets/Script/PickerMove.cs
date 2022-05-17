using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private Vector3 _firstTouchPosition;
    private Vector3 _curTouchPosition;
    [SerializeField] private float sensitivityMultiplier = 0.01f;
    private float _finalTouchX;
    private float _xBound = 2.58f;
    private bool _canMove = true;
    [SerializeField] private bool taptoplay;
    public GameObject PlayImg,Diamonds,DPanel;
    public ParticleSystem Confetti;
    private void Awake()
    {
        Confetti.Stop();
    }
    public void GamePlay()
    {
        taptoplay = true;
    }
    void FixedUpdate()
    {
       if (taptoplay)
        {
            PlayImg.SetActive(false);
            transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
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
            taptoplay = false;
            StartCoroutine(NextPlatfrom());
        }
        if (collision.gameObject.tag == "stop2")
        {
            taptoplay = false;
            StartCoroutine(NextPlatfrom());  
        }
        if (collision.gameObject.tag == "finish")
        {
            taptoplay = false;
            Confetti.Play();
            Instantiate(Diamonds, Camera.main.WorldToScreenPoint(transform.position), DPanel.transform.rotation, DPanel.transform);
            StartCoroutine(NextLevel());
        }
    }
    IEnumerator NextPlatfrom()
    {
        yield return new WaitForSeconds(3);
        taptoplay = true;
    }
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(Application.loadedLevel + 1);
    }
}