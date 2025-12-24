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

    private void PlaySE(string name)
    {

    }
}
