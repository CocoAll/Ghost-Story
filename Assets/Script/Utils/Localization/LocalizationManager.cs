using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    private static readonly string DEFAULT_LOCAL_REF = "en";

    private XMLLoader xmlLoader;
    [SerializeField]
    private LocaleValue locale;

    private Dictionary<string, string[]> entries;

    private void Start() 
    {
        LoadLocale();
    }

    public void LoadLocale()
    {
        string localeRef = FindLocaleRef();
        xmlLoader = new XMLLoader(localeRef);
        entries = xmlLoader.loadDictionnary();
    }

    public string[] GetDialogue(string key)
    {
        if (!entries.ContainsKey(key)){
            throw new System.Exception("Impossible to found " + key + " in localization file");
        }

        return entries[key];
    }

    private string FindLocaleRef()
    {
        foreach(Locale loc in locale.availableLocale)
        {
            if(loc.locale == locale.currentLocale)
            {
                return loc.localeRef;
            }
        }

        return DEFAULT_LOCAL_REF;
    }
}
