using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public enum OperationType
{
	Translate,
	Rotate,
	Scale,
	Animation
}

public class QueueNode : MyNodeBase
{
	[Input(ShowBackingValue.Unconnected,ConnectionType.Override,TypeConstraint.None,false)]public EmptyPort startNode;
	[Output(connectionType = ConnectionType.Override)] public EmptyPort nextNode;
	public string mainGameobject;
	[Multiline]
	public string TipString;
	public OperationType operationType;
	public AudioClip endAudio;
	public float goal;
	public List<AnimationInfo> anim;

	// 初始化
	protected override void Init()
	{
		base.Init();
	}

	public override object GetValue(NodePort port)
	{
		return null; 
	}
}
[System.Serializable]
public class AnimationInfo
{
	public string animObj;
	public string animName;
}