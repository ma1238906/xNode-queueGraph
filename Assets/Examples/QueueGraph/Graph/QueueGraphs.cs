using System;
using System.IO;
using System.Xml;
using UnityEngine;
using XNode;

[Serializable, CreateAssetMenu(fileName = "流程图", menuName = "xNode Examples/Queue Graph")]
public class QueueGraphs : NodeGraph
{
    public EntryNode entryNode;
    private string localPath = Application.streamingAssetsPath + "/";
    public void CreateXML()
    {
        XmlDocument xml = new XmlDocument();
        xml.CreateXmlDeclaration("1.0", "UTF-8", "yes");//设置xml文件编码格式为UTF-8
        EntryXML(xml);
    }

    private int index;
    private void EntryXML(XmlDocument xml)
    {
        index = 0;
        XmlElement root = xml.CreateElement("Root");//创建根节点
        if (entryNode == null) return;
        root.SetAttribute("Name", entryNode.Name);
        root.SetAttribute("TotalTime", entryNode.TotalTime);
        root.SetAttribute("TotalScores", entryNode.TotalScores);
        xml.AppendChild(root);

        NodePort exitPort = entryNode.GetOutputPort("outPort");
        if (!exitPort.IsConnected) return;
        QueueNode node = exitPort.Connection.node as QueueNode;
        QueueXML(xml, root,node);
        xml.Save(localPath+entryNode.Name+".xml");//保存xml到路径位置
    }

    private void QueueXML(XmlDocument xml,XmlElement root,QueueNode node)
    {
        index++;
        XmlElement user = xml.CreateElement("User");
        XmlElement data = xml.CreateElement("MainInfo");
        if (entryNode != null)
        {
            if(entryNode.outPort != null)
            {
                user.SetAttribute("id",index.ToString());
                data.SetAttribute("MainObject", node.mainGameobject);
                data.SetAttribute("TipStr", node.TipString);
                data.SetAttribute("OperationType", node.operationType.ToString());
                data.SetAttribute("EndAudio", node.endAudio==null? "": node.endAudio.name);
                data.SetAttribute("CurrentScore", node.goal.ToString());
                user.AppendChild(data);

                if(node.anim.Count > 0)
                {
                    XmlElement anims = xml.CreateElement("Anims");
                    foreach(AnimationInfo i in node.anim)
                    {
                        XmlElement anim = xml.CreateElement("Anim");
                        anim.SetAttribute("obj", i.animObj);
                        anim.SetAttribute("anim", i.animName);
                        anims.AppendChild(anim);
                    }
                    user.AppendChild(anims);
                }
                root.AppendChild(user);

                NodePort nextPort = node.GetOutputPort("nextNode");
                if (!nextPort.IsConnected) return;
                QueueNode nextNode = nextPort.Connection.node as QueueNode;
                QueueXML(xml, root, nextNode);
            }
        }
    }


    public override Node AddNode(Type type)
    {
        return base.AddNode(type);
    }
}
