using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TentativeLogger : MonoBehaviour
{
    [SerializeField] private TextMesh logTextMesh;

    private void Awake()
    {
        if (logTextMesh == null)
        {
            logTextMesh = GetComponent<TextMesh>();
        }
    }


    void Update()
    {
        //適当なログを出したいとき
        logTextMesh.text = Time.realtimeSinceStartup.ToString("F2");
    }
}
