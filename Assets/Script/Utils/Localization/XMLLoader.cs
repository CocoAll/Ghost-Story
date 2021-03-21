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

    public Dictionary<string,string> loadDictionnary()
    {
        Dictionary<string, string> dico = new Dictionary<string, string>();
        XmlNodeList list = xmlDoc.DocumentElement.SelectNodes("/entries/entry");
        foreach (XmlNode node in list)
        {
            string key = node.Attributes["name"].Value;
            string value = node.Attributes["value"].Value;
            dico.Add(key, value);
        }
        return dico;
    }
}
