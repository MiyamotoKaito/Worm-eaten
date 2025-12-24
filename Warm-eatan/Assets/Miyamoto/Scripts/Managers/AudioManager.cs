using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public class SoundData : MonoBehaviour
    {
        public AudioClip Clip;
        public string Name;
    }

    [SerializeField] private List<SoundData> _seList;
    [SerializeField] private List<SoundData> _bgmList;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// SEを流す
    /// </summary>
    /// <param name="name"></param>
    public void PlaySE(string name)
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
