using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public abstract class QueueNodeBase : MyNodeBase
{
    public enum OperatorType
    {
        User1,
        User2,
        User3
    }

    public OperatorType Operator;

}