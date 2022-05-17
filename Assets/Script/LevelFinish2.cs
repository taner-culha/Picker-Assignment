using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class LevelFinish2 : MonoBehaviour
{
    public Text ScoreText;
    public int Score=0;
    public GameObject PickerTarget,L1,L2, OpenDoorLeft, OpenDoorRight;
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
            Score += 1;
            ScoreText.text = Score.ToString();       
            if (Score >= 10)
            {
                Confetti.Play();
                OpenDoorLeft.GetComponent<DoorOpenAnim>().OpenLeft();
                OpenDoorRight.GetComponent<DoorOpenAnim>().OpenRight();
                L2.GetComponent<Image>().color = Color.green;
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