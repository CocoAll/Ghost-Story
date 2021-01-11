using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Locale Object", menuName = "Scriptable Object/Locale", order = 6)]
public class LocaleValue : ScriptableObject
{

    public SystemLanguage currentLocale;
    
    public Locale[] availableLocale;
}
