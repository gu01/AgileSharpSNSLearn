using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace AgileSharp.SNS.Infrastructure.Files
{
    public static class ConfigurationReader
    {
        public static XmlNode FindElements(string configPath, string nodeName)
        {
            XmlNode result = null;

            if (configPath.IsNotEmpty() && File.Exists(configPath) && nodeName.IsNotEmpty())
            {
                XmlDocument document = new XmlDocument();
                document.Load(configPath);
                var node = VisitorNode(document.DocumentElement, nodeName);
                if (node != null)
                {
                    result = node;
                }
            }
            return result;
        }


        private static XmlNode VisitorNode(XmlNode node, string nodeName)
        {           
            if (string.Compare(node.Name, nodeName) == 0)
            {
               return  node;
            }
            else
            {
                if (node.HasChildNodes)
                {
                    var nodes = node.ChildNodes;
                    foreach (XmlNode childNode in nodes)
                    {
                       var tempNode= VisitorNode(childNode, nodeName);
                       if (tempNode != null)
                           return tempNode;
                        
                    }
                }
            }
            return null ;
        }

    }
}
