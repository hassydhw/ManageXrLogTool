using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagChecker : MonoBehaviour
{
    [SerializeField] private TextMesh logTextMesh;
    [SerializeField] private float interval = 1.0f;
    [SerializeField] private string[] searchTags;
    private float accumlatedTime;


    private void Start()
    {
        if (logTextMesh == null)
        {
            logTextMesh = GetComponent<TextMesh>();
        }
    }

    private void Update()
    {
        accumlatedTime += Time.deltaTime;

        if (accumlatedTime >= interval)
        {
            accumlatedTime = 0;
            CheckTags();
        }
    }

    void CheckTags()
    {
        Debug.Log("do action");
        try
        {
            string tempString = "";
            for (int i = 0; i < searchTags.Length; i++)
            {
                var tempTargetObj = GameObject.FindGameObjectsWithTag(searchTags[i]);
                tempString = tempString + $"\n{searchTags[i]}: {tempTargetObj.Length}";
            }

            logTextMesh.text = tempString;
        }
        catch (Exception e)
        {
            logTextMesh.text = "タグ取得時にエラー\n" + e.Message;
        }
    }
}
