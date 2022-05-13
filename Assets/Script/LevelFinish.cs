using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class LevelFinish : MonoBehaviour
{
    public Text ScoreText;
    int score=0;
    public GameObject PickerTarget;
    public Transform PlatformNext;
    public float Time;
    public ParticleSystem Confetti;
    private void Awake()
    {
        Confetti.Stop();
    }
    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "sphere")
        {
            score += 1;
            ScoreText.text = score.ToString();       
            if (score >= 5)
            {
                Confetti.Play();
                PickerTarget.transform.DOMoveZ(PlatformNext.position.z, Time);
                PickerTarget.GetComponent<PickerMove>().GamePlay();
            }
            else
            {
                StartCoroutine(NextPlatfrom());     
            }
        }
    }
    IEnumerator NextPlatfrom()
    {
        yield return new WaitForSeconds(5);
        //Restart();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}