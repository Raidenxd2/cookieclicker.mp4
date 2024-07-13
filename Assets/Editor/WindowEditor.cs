using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WindowAnimations))]
public class WindowEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        WindowAnimations wa = (WindowAnimations)target;

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Hide Window"))
        {
            wa.transform.localScale = new Vector3(0, 0, 0);
            // Cookieclicker2.mp4 only wa.transform.rotation = new Quaternion(0, 0, 0, 0);
            // Cookieclicker2.mp4 only wa.transform.Rotate(new Vector3(-90, 0, 0));
            wa.gameObject.SetActive(false);
        }

        if (GUILayout.Button("Show Window"))
        {
            wa.transform.localScale = new Vector3(1, 1, 1);
            // Cookieclicker2.mp4 only wa.transform.rotation = new Quaternion(0, 0, 0, 0);
            // Cookieclicker2.mp4 only wa.transform.Rotate(new Vector3(0, 0, 0));
            wa.gameObject.SetActive(true);
        }
        GUILayout.EndHorizontal();
    }
}
