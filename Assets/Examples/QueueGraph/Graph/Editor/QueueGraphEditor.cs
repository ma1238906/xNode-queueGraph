using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;

[CustomNodeGraphEditor(typeof(QueueGraphs))]
public class QueueGraphEditor : NodeGraphEditor
{
    public override void OnGUI()
    {
        base.OnGUI();
        if(GUI.Button(new Rect(20,20,70,18),"生成XML"))
        {
            QueueGraphs qg = target as QueueGraphs;
            qg.CreateXML();
        }
    }
    public override void OnCreate()
    {
        base.OnCreate();
    }
}
