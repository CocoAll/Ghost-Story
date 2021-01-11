using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class XMLLoader
{
    private XmlDocument xmlDoc = null;
    private string xmlExtension = ".xml";

    public XMLLoader(string locale)
    {
        string fileName = locale + xmlExtension;
        xmlDoc = new XmlDocument();
        try
        {
            TextAsset textAsset = (TextAsset)Resources.Load(locale);
            xmlDoc.LoadXml(textAsset.text);
        }
        catch
        {
            throw new FileNotFoundException("Le fichier n'a pas été trouvé");
        }
    }

    public Dictionary<string,string[]> loadDictionnary()
    {
        Dictionary<string, string[]> dictio = new Dictionary<string, string[]>();
        XmlNodeList list = xmlDoc.DocumentElement.SelectNodes("/entries/entry");
        foreach (XmlNode node in list)
        {
            string key = node.Attributes["name"].Value;
            List<string> value = new List<string>();
            foreach(XmlNode subNode in node.ChildNodes)
            {
                value.Add(subNode.Attributes["value"].Value);
            }
            dictio.Add(key, value.ToArray());
        }
        return dictio;
    }
}
