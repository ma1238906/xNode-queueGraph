using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// 为了能在xNodeGraph编辑器中使用场景中物体，需要在Scene中添加一个用来保存数据的组件
/// 然后再在NodeEditor中使用GUI绘制出来物体拾取器
/// </summary>
public class SceneObjects : MonoBehaviour
{
    public List<NodeList> nodeLists = new List<NodeList>();
    public void Add(QueueNode index,GameObject value)
    {
        NodeList temp = nodeLists.SingleOrDefault(a =>  a.node == index);
        if(temp == null)
        {
            nodeLists.Add(new NodeList() { node = index, target = value });
        }
        else
        {
            temp.target = value;
        }
    }

    public void Remove(QueueNode index)
    {
        NodeList temp = nodeLists.SingleOrDefault(a => a.node == index);
        if (temp != null)
        {
            nodeLists.Remove(temp);
        }
    }

    public GameObject Get(QueueNode index)
    {
        NodeList temp = nodeLists.SingleOrDefault(a => a.node == index);
        if (temp != null)
        {
            return temp.target;
        }
        return null;
    }

    [System.Serializable]
    public class NodeList
    {
        public QueueNode node;
        public GameObject target;
    }
}

