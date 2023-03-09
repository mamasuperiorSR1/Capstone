using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Motify : MonoBehaviour
{
    public static float ratio = 0.5f;
    [MenuItem("Tools/Modify")]
    public static void MM()
    {
        foreach(var obj in Selection.gameObjects)
        {
            foreach(Transform child in obj.GetComponentsInChildren<Transform>())
            {
                child.localPosition = new Vector3(ratio* child.localPosition.x, child.localPosition.y,ratio* child.localPosition.z);
            }
        }
    }
}
