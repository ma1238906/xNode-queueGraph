using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;
using System.Diagnostics;

[CustomNodeEditor(typeof(QueueNode))]
public class QueueNodeEditor : NodeEditor
{
    public override void OnHeaderGUI()
    {
        string title = "流程";
        GUILayout.Label(title, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
        GUI.color = Color.white;
    }

    private string audioName;
    public override void OnBodyGUI()
    {
        base.OnBodyGUI();
        GUILayout.Space(8);
        GUILayout.BeginHorizontal();
        GUILayout.Label("语音名称:");
        audioName = GUILayout.TextField(audioName, new GUILayoutOption[] { GUILayout.Width(80) });
        GUILayout.Label(".wav");
        GUILayout.EndHorizontal();
        if (GUILayout.Button("生成配音"))
        {
            QueueNode qn = target as QueueNode;
            TextToAudio(audioName, qn.TipString);
        }
    }

    private void TextToAudio(string fileName, string text)
    {
        Process process = new Process();
        ProcessStartInfo pInfo = new ProcessStartInfo();
        pInfo.FileName = Application.dataPath + "/Plugins/CSharpTTS.exe";
        pInfo.CreateNoWindow = false;
        pInfo.Arguments = fileName+" "+text;
        process.StartInfo = pInfo;
        process.Start();
    }
}
