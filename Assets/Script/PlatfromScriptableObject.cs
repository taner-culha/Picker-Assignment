using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromScriptableObject : MonoBehaviour
{
    [SerializeField] private PlatformType platform=null;
    void Start()
    {
        GetComponent<Renderer>().material.color = platform.PlatformColor;
        transform.localScale = platform.PlatformScale;
    }
}
