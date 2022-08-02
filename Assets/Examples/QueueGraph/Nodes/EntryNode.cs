using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class EntryNode : MyNodeBase
{
    [Output]public EmptyPort outPort;
    public string Name;
    public string TotalTime;
    public string TotalScores;
}