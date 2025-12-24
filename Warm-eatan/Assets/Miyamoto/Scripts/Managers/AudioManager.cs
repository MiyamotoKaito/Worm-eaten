using System.Collections.Generic;
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
}
