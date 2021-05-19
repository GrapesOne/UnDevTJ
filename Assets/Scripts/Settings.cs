using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Toggle Music, Sounds;

    public void Start()
    {
        Music.isOn = PlayerPrefs.GetInt("music", 1) == 1 ;
        Sounds.isOn = PlayerPrefs.GetInt("sounds", 1) == 1;
    }
    public void Save()
    {
        PlayerPrefs.SetInt("music", Music.isOn ? 1 : 0);
        PlayerPrefs.SetInt("sounds", Sounds.isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
