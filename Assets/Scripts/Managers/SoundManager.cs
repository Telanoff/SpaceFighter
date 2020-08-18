using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static readonly string TIMESTAMP = "timestamp";

    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.time = PlayerPrefs.GetFloat(TIMESTAMP);
    }

    public void Save()
    {
        PlayerPrefs.SetFloat(TIMESTAMP, source.time);
        PlayerPrefs.Save();
    }
}
