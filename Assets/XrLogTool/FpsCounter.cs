using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
    float UpdateInterval = 0.5f;

    int Flames = 0;
    float TimeLeft = 0.0f;
    float Fps = 0.0f;
    float Accum = 0.0f;

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
        this.TimeLeft -= Time.deltaTime;
        this.Accum += Time.timeScale / Time.deltaTime;
        this.Flames++;

        if (0 < this.TimeLeft)
        {
            return;
        }

        this.Fps = this.Accum / this.Flames;
        this.TimeLeft = this.UpdateInterval;
        this.Accum = 0.0f;
        this.Flames = 0;

        logTextMesh.text = string.Format("FPS: {0:#.0}", this.Fps);
    }
}
