using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    public GameObject PickerTarget;
    public Transform PlatformNext;
    public float Time;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "finish")
        {
            PickerTarget.transform.DOMoveZ(PlatformNext.position.z, Time);
            PickerTarget.GetComponent<PickerMove>().GamePlay();
            PickerTarget.transform.Rotate(new Vector3(0, Time * 10f, 0));
            StartCoroutine(NextPlatfrom());
        }    
    }
    IEnumerator NextPlatfrom()
    {
        yield return new WaitForSeconds(5);
        //SceneManager.LoadScene(Application.loadedLevel + 1);
    }
}
