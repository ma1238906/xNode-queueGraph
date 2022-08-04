using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNodeEditor;

[CustomNodeEditor(typeof(EntryNode))]
public class EntryNodeEditor : NodeEditor
{
    public override void OnHeaderGUI()
    {
        GUI.color = Color.white;
        EntryNode node = target as EntryNode;
        QueueGraphs graph = node.graph as QueueGraphs;
        if (graph.entryNode == node) GUI.color = Color.yellow;
        //string title = target.name;
        string title = "开始";
        GUILayout.Label(title, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
        GUI.color = Color.white;
    }

    public override void OnBodyGUI()
    {
        base.OnBodyGUI();
        if(GUILayout.Button("设为开始节点"))
        {
            QueueGraphs graph = (target as EntryNode).graph as QueueGraphs;
            graph.entryNode = target as EntryNode;
        }
    }
}
