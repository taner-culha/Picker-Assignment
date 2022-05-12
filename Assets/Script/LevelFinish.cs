using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class LevelFinish : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private Text _scoreText;
    /*dotween*/
    public Transform PlatformNext;
    public float Time;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "sphere")
        {
            _score += 1;
            _scoreText.text = _score.ToString();
            if (_score >= 5)
            {
                StartCoroutine(NextPlatfrom());
            }
            else
            {
                Restart();
            }
        }
    }
    IEnumerator NextPlatfrom()
    {
        yield return new WaitForSeconds(5);
        transform.DOMoveZ(PlatformNext.position.z, Time);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}