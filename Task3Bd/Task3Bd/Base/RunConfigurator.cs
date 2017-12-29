using System;
using System.Xml;

namespace Task3Bd.Base
{
    public class RunConfigurator
    {   
        private static XmlDocument xmlDoc = new XmlDocument();
            
        public static String GetValue(String tag)
        {   
            xmlDoc.Load(Environment.CurrentDirectory + "/Task3Bd/Resources/run.xml");
            XmlNodeList browser = xmlDoc.GetElementsByTagName(tag);
            return browser[0].InnerText;
        }
    }
}
