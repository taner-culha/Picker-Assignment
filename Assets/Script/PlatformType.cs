using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Platform", menuName = "Platform")]
public class PlatformType : ScriptableObject
{
    public Color PlatformColor = Color.green;
    public Vector3 PlatformScale = Vector3.one;
}
