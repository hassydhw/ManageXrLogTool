using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogMessageManager : MonoBehaviour
{
    [SerializeField] private string screeningText = "";


    [SerializeField, Tooltip("デバッグログ用テキストオブジェクト")]
    private GameObject p_TargetDebugPanelObject;
    private TextMesh p_Text;

    [SerializeField] private bool doesStacktraceInclude = false;

    [SerializeField]
    private int p_LineNum = 20;

    [SerializeField]
    private int p_letterNum = 100;


    private string p_TextMessage;
    string newline;



    private void Awake()
    {
        // Logメッセージイベント追加
        Application.logMessageReceived += LogMessageOutput;
    }

    private void Start()
    {//こいつをAwakeでかくとインスペクターでオフにできなくなってしまうのでStartで書いておく
        newline = System.Environment.NewLine;
        p_Text = p_TargetDebugPanelObject.GetComponent<TextMesh>();
    }


    private void LogMessageOutput(string condition, string stackTrace, LogType type)
    {
        if (p_Text != null)
        {
            string textmessage = p_Text.text;

            //スクリーニングテキストになにか指定があれば、それを含まないときは表示しない
            if (!string.IsNullOrEmpty(screeningText))
            {
                if (!condition.Contains(screeningText))
                {
                    return;
                }
            }

            textmessage = condition + newline + textmessage;
            if (doesStacktraceInclude)
            {
                textmessage = stackTrace + newline + textmessage;
            }

            string[] lines = textmessage.Split(new string[] { newline }, System.StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length > p_LineNum)
            {
                textmessage = "";
                for (int line = 0; line < p_LineNum; line++)
                {
                    string lineString = lines[line];
                    if (lineString.Length > p_letterNum)
                    {
                        lineString = lineString.Substring(0, p_letterNum);
                    }
                    textmessage += lineString + newline;
                }
            }
            p_Text.text = textmessage;
        }


    }


    private void OnApplicationQuit()
    {
        Application.logMessageReceived -= LogMessageOutput;
    }

}
