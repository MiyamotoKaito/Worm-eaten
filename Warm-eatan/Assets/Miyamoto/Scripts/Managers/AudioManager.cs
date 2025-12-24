using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public class SoundData
    {
        public AudioClip Clip;
        public string Name;
    }

    [SerializeField] private List<SoundData> _seList;
    [SerializeField] private List<SoundData> _bgmList;

    /// <summary>
    /// SEを流す
    /// </summary>
    /// <param name="name"></param>
    private void PlaySE(string name)
    {
        foreach (var se in _seList)
        {
            if (se.Name == name)
            {
                var player = new GameObject("SEPlayer").AddComponent<AudioSource>();
                player.clip = se.Clip;
                player.Play();
            }
        }
    }
}
