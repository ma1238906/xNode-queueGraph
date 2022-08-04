using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class EntryNode : MyNodeBase
{
    [Output(connectionType =ConnectionType.Override)]public EmptyPort outPort;
    public string Name;
    public string TotalTime;
    public string TotalScores;
}